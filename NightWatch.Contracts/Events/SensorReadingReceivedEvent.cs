using NightWatch.Contracts.Common.Enums;

namespace NightWatch.Contracts.Events;

/// <summary>
///     Событие о получении показания датчика
/// </summary>
public class SensorReadingReceivedEvent
{
    /// <summary>
    ///     Идентификатор показания
    /// </summary>
    public Guid ReadingId { get; set; }
    
    /// <summary>
    ///     Идентификатор датчика
    /// </summary>
    public Guid SensorId { get; set; }
    
    /// <summary>
    ///     Тип датчика
    /// </summary>
    public SensorType SensorType { get; set; }
    
    /// <summary>
    ///     Полезная нагрузка
    /// </summary>
    public string Payload { get; set; }
    
    /// <summary>
    ///     Время срабатывания датчика
    /// </summary>
    public DateTime Timestamp { get; set; }
    
    /// <summary>
    ///     Местоположение
    /// </summary>
    public string Location { get; set; }
}