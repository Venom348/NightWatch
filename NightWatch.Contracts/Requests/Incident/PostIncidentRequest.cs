using NightWatch.Contracts.Common.Enums;

namespace NightWatch.Contracts.Requests.Incident;

/// <summary>
///     Класс для отправки данных об инциденте на сервер
/// </summary>
public class PostIncidentRequest
{
    /// <summary>
    ///     Тип инцидента
    /// </summary>
    public IncidentType Type { get; set; }
    
    /// <summary>
    ///     Строгость инцидента
    /// </summary>
    public Severity Severity { get; set; }
    
    /// <summary>
    ///     Тип датчика для поиска правила классификации
    /// </summary>
    public SensorType SensorType { get; set; }
    
    /// <summary>
    ///     Местоположение
    /// </summary>
    public string Location { get; set; }
}