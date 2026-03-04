using Incident.Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Incident.Infrastructure.Repositories;

/// <inheritdoc cref="IBaseRepository{Incident}" />
public class IncidentRepository: IBaseRepository<Domain.Entities.Incident>
{
    private readonly ApplicationContext _dbContext;

    public IncidentRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Получение всех записей
    public IQueryable<Domain.Entities.Incident> GetAll() => _dbContext.Incidents;

    // Получение по ID
    public async Task<Domain.Entities.Incident> GetById(Guid id) => await _dbContext.Incidents.FirstOrDefaultAsync(s => s.Id == id);

    // Создание сущности
    public async Task<Domain.Entities.Incident> Create(Domain.Entities.Incident entity)
    {
        _dbContext.Incidents.Add(entity);
        await SaveChangesAsync();
        return entity;
    }

    // Изменение сущности
    public async Task<Domain.Entities.Incident> Update(Domain.Entities.Incident entity)
    {
        _dbContext.Incidents.Update(entity);
        await SaveChangesAsync();
        return entity;
    }
    
    // Метод сохранения
    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}