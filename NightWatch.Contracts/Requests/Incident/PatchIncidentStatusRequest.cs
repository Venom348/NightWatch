using NightWatch.Contracts.Common.Enums;

namespace NightWatch.Contracts.Requests.Incident;

/// <summary>
///     Класс для обновления статуса инцидента на сервере
/// </summary>
public class PatchIncidentStatusRequest
{
    /// <summary>
    ///     Идентификатор инцидента
    /// </summary>
    public Guid Id {get; set; }

    /// <summary>
    ///     Статус инцидента
    /// </summary>
    public IncidentStatus Status { get; set; }
}