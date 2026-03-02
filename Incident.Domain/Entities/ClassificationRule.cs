using NightWatch.Contracts.Common;
using NightWatch.Contracts.Common.Enums;

namespace Incident.Domain.Entities;

/// <summary>
///     Модель правила классификации инцидента
/// </summary>
public class ClassificationRule : Entity
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