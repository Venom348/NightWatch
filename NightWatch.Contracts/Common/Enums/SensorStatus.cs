namespace NightWatch.Contracts.Common.Enums;

/// <summary>
///     Статус датчика
/// </summary>
public enum SensorStatus
{
    /// <summary>
    ///     Онлайн — датчик работает и присылает heartbeat
    /// </summary>
    Online = 1,
    
    /// <summary>
    ///     Офлайн — датчик не отвечает
    /// </summary>
    Offline = 2,
    
    /// <summary>
    ///     Неисправен — датчик шлёт некорректные данные
    /// </summary>
    Malfunction = 3,
    
    /// <summary>
    ///     На обслуживании — временно отключён
    /// </summary>
    Maintenance = 4
}