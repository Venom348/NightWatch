using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using SensorIngestion.Application.Abstractions;
using SensorIngestion.Application.Implementations.Services;
using SensorIngestion.Domain.Abstractions.Repositories;
using SensorIngestion.Domain.Abstractions.Services;
using SensorIngestion.Domain.Entities;
using SensorIngestion.Domain.Mapping;
using SensorIngestion.Infrastructure;
using SensorIngestion.Infrastructure.Messaging.Publishers;
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

// Создание фабрики подключений к RabbitMQ
var rabbitFactory = new ConnectionFactory
{
    HostName = configuration["RabbitMQ:HostName"],
    UserName = configuration["RabbitMQ:UserName"],
    Password = configuration["RabbitMQ:Password"]
};

// Создание одного соединение на всё приложение
var rabbitConnection = await rabbitFactory.CreateConnectionAsync();
builder.Services.AddSingleton(rabbitConnection);

builder.Services.AddSingleton<ISensorReadingPublisher, SensorReadingPublisher>();

var app = builder.Build();

app.MapControllers(); // Маршрутизация контроллеров
app.UseSwagger(); // Включает middleware для генерации Swagger JSON
app.UseSwaggerUI(); // Включает веб-интерфейс для документации API
app.UseHttpsRedirection(); // Перенаправляет HTTP запросы на HTTPS

app.Run();