using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SensorIngestion.Application.Implementations.Services;
using SensorIngestion.Domain.Abstractions.Repositories;
using SensorIngestion.Domain.Abstractions.Services;
using SensorIngestion.Domain.Entities;
using SensorIngestion.Domain.Mapping;
using SensorIngestion.Infrastructure;
using SensorIngestion.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration; // Получение доступа к конфигурации

// Регистрирует сервисы для работы с контроллерами и
// включает сериализацию enum в строковом виде для JSON
builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter());
    });
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ISensorIngestionService, SensorIngestionService>();
builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("Psql")));
builder.Services.AddTransient<IBaseRepository<Sensor>, SensorRepository>();
builder.Services.AddTransient<IBaseRepository<SensorReading>, SensorReadingRepository>();
builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfile<SensorProfile>();
    opt.AddProfile<SensorReadingProfile>();
});

var app = builder.Build();

app.MapControllers(); // Маршрутизация контроллеров
app.UseSwagger(); // Включает middleware для генерации Swagger JSON
app.UseSwaggerUI(); // Включает веб-интерфейс для документации API
app.UseHttpsRedirection(); // Перенаправляет HTTP запросы на HTTPS

app.Run();