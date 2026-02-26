using Microsoft.EntityFrameworkCore;
using SensorIngestion.Domain.Entities;

namespace SensorIngestion.Infrastructure;

/// <summary>
///     Модель подключения к БД
/// </summary>
public class ApplicationContext : DbContext
{
    //  Определение сущностей
    public DbSet<Sensor> Sensors => Set<Sensor>();
    public DbSet<SensorReading> SensorReadings => Set<SensorReading>();

    public ApplicationContext(DbContextOptions options) : base(options)
    {
        //  Проверка существования и создания БД
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