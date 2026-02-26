using NightWatch.Contracts.Common.Enums;

namespace NightWatch.Contracts.Requests.SensorIngestion;

/// <summary>
///     Класс для отправки данных о показания датчика на сервер
/// </summary>
public class PostSensorReadingRequest
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
    ///     Местоположение
    /// </summary>
    public string Location { get; set; }
}