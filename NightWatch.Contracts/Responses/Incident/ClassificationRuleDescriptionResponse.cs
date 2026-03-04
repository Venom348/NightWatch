using NightWatch.Contracts.Common.Enums;

namespace NightWatch.Contracts.Responses.Incident;

/// <summary>
///     Класс для предоставления полной информации о правиле классификации
/// </summary>
public class ClassificationRuleDescriptionResponse
{
    /// <summary>
    ///     Идентификатор правила
    /// </summary>
    public Guid Id {get; set; }
    
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