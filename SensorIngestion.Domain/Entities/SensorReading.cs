using NightWatch.Contracts.Common;
using NightWatch.Contracts.Common.Enums;

namespace SensorIngestion.Domain.Entities;

/// <summary>
///     Модель показания датчика
/// </summary>
public class SensorReading : Entity
{
    /// <summary>
    ///     Идентификатор датчика
    /// </summary>
    public Guid SensorId { get; set; }
    
    /// <summary>
    ///     Тип датчика
    /// </summary>
    public SensorType Type { get; set; }
    
    /// <summary>
    ///     Полезная нагрузка
    /// </summary>
    public string Payload { get; set; }
    
    /// <summary>
    ///     Дата и время срабатывания датчика
    /// </summary>
    public DateTime Timestamp { get; set; }
    
    /// <summary>
    ///     Местоположение
    /// </summary>
    public string Location { get; set; }
}