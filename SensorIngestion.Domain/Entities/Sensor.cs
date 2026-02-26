using NightWatch.Contracts.Common;
using NightWatch.Contracts.Common.Enums;

namespace SensorIngestion.Domain.Entities;

/// <summary>
///     Модель датчика
/// </summary>
public class Sensor : Entity
{
    /// <summary>
    ///     Тип датчика
    /// </summary>
    public SensorType Type { get; set; }
    
    /// <summary>
    ///     Местоположение
    /// </summary>
    public string Location { get; set; }
    
    /// <summary>
    ///     Статус
    /// </summary>
    public SensorStatus Status { get; set; }
    
    /// <summary>
    ///     Сигнал жизни
    /// </summary>
    public DateTime? LastHeartbeat { get; set; }
}