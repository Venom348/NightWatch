using Microsoft.EntityFrameworkCore;
using SensorIngestion.Domain.Abstractions.Repositories;
using SensorIngestion.Domain.Entities;

namespace SensorIngestion.Infrastructure.Repositories;

/// <inheritdoc cref="IBaseRepository{SensorReading}">
public class SensorReadingRepository : IBaseRepository<SensorReading>
{
    private readonly ApplicationContext _dbContext;

    public SensorReadingRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Получение всех записей
    public IQueryable<SensorReading> GetAll() => _dbContext.SensorReadings;

    // Получение по ID
    public async Task<SensorReading> GetById(Guid id) => await _dbContext.SensorReadings.FirstOrDefaultAsync(s => s.Id == id);

    // Создание сущности
    public async Task<SensorReading> Create(SensorReading entity)
    {
        _dbContext.SensorReadings.Add(entity);
        await SaveChangesAsync();
        return entity;
    }

    // Обновление сущности
    public async Task<SensorReading> Update(SensorReading entity)
    {
        _dbContext.SensorReadings.Update(entity);
        await SaveChangesAsync();
        return entity;
    }

    // Метод сохранения
    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}