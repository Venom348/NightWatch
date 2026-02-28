using NightWatch.Contracts.Events;

namespace SensorIngestion.Application.Abstractions;

/// <summary>
///     Интерфейс для публикации событий о показаниях датчиков в RabbitMQ
/// </summary>
public interface ISensorReadingPublisher
{
    /// <summary>
    ///     Публикует событие о новом показании датчика
    /// </summary>
    Task PublishAsync(SensorReadingReceivedEvent @event);
}