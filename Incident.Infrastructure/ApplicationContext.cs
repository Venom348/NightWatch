using Incident.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Incident.Infrastructure;

/// <summary>
///     Модель подключения к БД
/// </summary>
public class ApplicationContext : DbContext
{
    // Определение сущностей
    public DbSet<Domain.Entities.Incident> Incidents => Set<Domain.Entities.Incident>();
    public DbSet<ClassificationRule> ClassificationRules => Set<ClassificationRule>();

    public ApplicationContext(DbContextOptions options) : base(options)
    {
        // Проверка существования БД и создание её
        if (Database.EnsureCreated())
        {
            Init();
        }
    }

    private void Init()
    {
        SaveChanges();
    }
}