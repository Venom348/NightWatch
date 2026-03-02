namespace NightWatch.Contracts.Common.Enums;

/// <summary>
///     Статус инцидента
/// </summary>
public enum IncidentStatus
{
    /// <summary>
    ///     Новый
    /// </summary>
    New = 1,
    
    /// <summary>
    ///     Подтвержденный
    /// </summary>
    Acknowledged = 2,
    
    /// <summary>
    ///     В процессе
    /// </summary>
    InProgress = 3,
    
    /// <summary>
    ///     Решённый
    /// </summary>
    Resolved = 4,
    
    /// <summary>
    ///     Ложная тревога
    /// </summary>
    FalseAlarm = 5
}