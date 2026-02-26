using NightWatch.Contracts.Common.Enums;

namespace NightWatch.Contracts.Requests.SensorIngestion;

/// <summary>
///     Класс для отправки данных о датчике на сервер
/// </summary>
public class PostSensorRequest
{
    /// <summary>
    ///     Тип датчика
    /// </summary>
    public SensorType Type { get; set; }
    
    /// <summary>
    ///     Местоположение
    /// </summary>
    public string Location { get; set; }
}