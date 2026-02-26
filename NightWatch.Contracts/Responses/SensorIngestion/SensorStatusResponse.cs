using NightWatch.Contracts.Common.Enums;

namespace NightWatch.Contracts.Responses.SensorIngestion;

/// <summary>
///     Класс для предоставления статуса у датчика
/// </summary>
public class SensorStatusResponse
{
    /// <summary>
    ///     Идентификатор датчика
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    ///     Статус
    /// </summary>
    public SensorStatus Status { get; set; }
}