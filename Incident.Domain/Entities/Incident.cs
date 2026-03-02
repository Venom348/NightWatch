using NightWatch.Contracts.Common;
using NightWatch.Contracts.Common.Enums;

namespace Incident.Domain.Entities;

/// <summary>
///     Модель инцидента
/// </summary>
public class Incident : Entity
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
    ///     Статус инцидента
    /// </summary>
    public IncidentStatus Status { get; set; }
    
    /// <summary>
    ///     Местоположение
    /// </summary>
    public string Location { get; set; }
    
    /// <summary>
    ///     Дата и время создание инцидента
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    ///     Дата и время решения инцидента
    /// </summary>
    public DateTime? ResolvedAt  { get; set; }
}