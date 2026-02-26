using NightWatch.Contracts.Common.Enums;

namespace NightWatch.Contracts.Responses.SensorIngestion;

/// <summary>
///     Класс для предоставления информации о показании датчика
/// </summary>
public class SensorReadingDescriptionResponse
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