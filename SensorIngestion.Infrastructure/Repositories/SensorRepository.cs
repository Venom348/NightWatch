using Microsoft.EntityFrameworkCore;
using SensorIngestion.Domain.Abstractions.Repositories;
using SensorIngestion.Domain.Entities;

namespace SensorIngestion.Infrastructure.Repositories;

/// <inheritdoc cref="IBaseRepository{Sensor}">
public class SensorRepository : IBaseRepository<Sensor>
{
    private readonly ApplicationContext _dbContext;

    public SensorRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Получение всех записей
    public IQueryable<Sensor> GetAll() => _dbContext.Sensors;

    // Получение по ID
    public async Task<Sensor> GetById(Guid id) => await _dbContext.Sensors.FirstOrDefaultAsync(s => s.Id == id);

    // Создание сущности
    public async Task<Sensor> Create(Sensor entity)
    {
        _dbContext.Sensors.Add(entity);
        await SaveChangesAsync();
        return entity;
    }

    // Обновление сущности
    public async Task<Sensor> Update(Sensor entity)
    {
        _dbContext.Sensors.Update(entity);
        await SaveChangesAsync();
        return entity;
    }

    // Метод сохранения
    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}