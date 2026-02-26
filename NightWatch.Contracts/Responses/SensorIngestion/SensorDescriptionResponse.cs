using NightWatch.Contracts.Common.Enums;

namespace NightWatch.Contracts.Responses.SensorIngestion;

/// <summary>
///     Класс для предоставления информации о датчике
/// </summary>
public class SensorDescriptionResponse
{
    /// <summary>
    ///     Идентификатор датчика
    /// </summary>
    public Guid Id { get; set; }
    
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