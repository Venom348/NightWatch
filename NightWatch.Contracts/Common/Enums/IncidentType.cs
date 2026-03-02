namespace NightWatch.Contracts.Common.Enums;

/// <summary>
///     Тип инцидента
/// </summary>
public enum IncidentType
{
    /// <summary>
    ///     Несанкционированный доступ
    /// </summary>
    UnauthorizedAccess = 1,
    
    /// <summary>
    ///     Подозрительная активность
    /// </summary>
    SuspiciousActivity = 2,
    
    /// <summary>
    ///     Сбой в работе
    /// </summary>
    InfrastructureFailure = 3,
    
    /// <summary>
    ///     Чрезвычайная ситуация
    /// </summary>
    Emergency = 4
}