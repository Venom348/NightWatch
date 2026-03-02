using System.Text;
using System.Text.Json;
using NightWatch.Contracts.Events;
using RabbitMQ.Client;
using SensorIngestion.Application.Abstractions;

namespace SensorIngestion.Infrastructure.Messaging.Publishers;

public class SensorReadingPublisher : ISensorReadingPublisher, IDisposable
{
    private readonly IConnection _connection; // Соединение с RabbitMQ
    private readonly IChannel _channel; // Канал для отправки сообщений
    
    // Имя Exchange
    private const string ExchangeName = "sensor.event";

    public SensorReadingPublisher(IConnection connection)
    {
        _connection = connection;
        
        // Создание канала, через него идут все операции
        _channel = _connection.CreateChannelAsync().GetAwaiter().GetResult();
        
        // Объявление topic exchange — он маршрутизирует сообщения по routing key с wildcards
        _channel.ExchangeDeclareAsync(
            exchange: ExchangeName,
            type: ExchangeType.Topic,
            durable: true) // переживёт перезапуск RabbitMQ
            .GetAwaiter().GetResult();
    }
    
    public async Task PublishAsync(SensorReadingReceivedEvent @event)
    {
        // Сериализация событий в JSON
        var json = JsonSerializer.Serialize(@event);
        var body = Encoding.UTF8.GetBytes(json);

        var properties = new BasicProperties
        {
            // Сообщение переживёт перезапуск RabbitMQ
            Persistent = true,
            
            // Идентификатор сообщения
            MessageId = Guid.NewGuid().ToString(),
            
            // Время отправки сообщения
            Timestamp = new AmqpTimestamp(DateTimeOffset.UtcNow.ToUnixTimeSeconds()),
        };

        // Routing key определяет куда именно попадёт сообщение внутри exchange
        var routingKey = $"sensor.{@event.SensorType.ToString().ToLower()}";

        // Публикация сообщений в exchange
        await _channel.BasicPublishAsync(
            exchange: ExchangeName,
            routingKey: routingKey, // Ключ маршрутизации
            mandatory: false,   // Не бросать ошибку, если нет подходящей очереди
            basicProperties: properties,
            body: body);
    }

    public void Dispose()
    {
        // Закрытие канала и соединение при уничтожении объекта
        _channel?.CloseAsync();
        _connection?.CloseAsync();
    }
}