using NightWatch.Contracts.Common.Enums;

namespace NightWatch.Contracts.Responses.Incident;

/// <summary>
///     Класс для предоставления полной информации об инциденте
/// </summary>
public class IncidentDescriptionResponse
{
    /// <summary>
    ///     Идентификатор инцидента
    /// </summary>
    public Guid Id {get; set; }
    
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