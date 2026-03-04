using NightWatch.Contracts.Common.Enums;

namespace NightWatch.Contracts.Requests.Incident;

/// <summary>
///     Класс для отправки данных о правиле классификации на сервер
/// </summary>
public class PostClassificationRuleRequest
{
    /// <summary>
    ///     Тип датчика
    /// </summary>
    public SensorType TriggerSensorType { get; set; }
    
    /// <summary>
    ///     Тип инцидента
    /// </summary>
    public IncidentType ResultingIncidentType { get; set; }
    
    /// <summary>
    ///     Серьёзность инцидента
    /// </summary>
    public Severity ResultingSeverity { get; set; }
    
    /// <summary>
    ///     Описание правила
    /// </summary>
    public string Description { get; set; }
}