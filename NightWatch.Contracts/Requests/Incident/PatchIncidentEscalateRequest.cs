using NightWatch.Contracts.Common.Enums;

namespace NightWatch.Contracts.Requests.Incident;

/// <summary>
///     Класс для обновления строгости инцидента на сервере
/// </summary>
public class PatchIncidentEscalateRequest
{
    /// <summary>
    ///     Идентификатор инцидента
    /// </summary>
    public Guid Id {get; set; }
    
    /// <summary>
    ///     Строгость инцидента
    /// </summary>
    public Severity Severity { get; set; }
}