using Incident.Domain.Abstractions.Repositories;
using Incident.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Incident.Infrastructure.Repositories;

/// <inheritdoc cref="IBaseRepository{ClassificationRule}" />
public class ClassificationRuleRepository : IBaseRepository<ClassificationRule>
{
    private readonly ApplicationContext _dbContext;

    public ClassificationRuleRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Получение всех записей
    public IQueryable<ClassificationRule> GetAll() => _dbContext.ClassificationRules;

    // Получение по ID
    public async Task<ClassificationRule> GetById(Guid id) => await _dbContext.ClassificationRules.FirstOrDefaultAsync(s => s.Id == id);

    // Создание сущности
    public async Task<ClassificationRule> Create(ClassificationRule entity)
    {
        _dbContext.ClassificationRules.Add(entity);
        await SaveChangesAsync();
        return entity;
    }

    // Изменение сущности
    public async Task<ClassificationRule> Update(ClassificationRule entity)
    {
        _dbContext.ClassificationRules.Update(entity);
        await SaveChangesAsync();
        return entity;
    }

    // Метод сохранения
    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}