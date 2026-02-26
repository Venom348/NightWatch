namespace NightWatch.Contracts.Common.Enums;

/// <summary>
///     Тип датчика
/// </summary>
public enum SensorType
{
    /// <summary>
    ///     Камера
    /// </summary>
    Camera = 1,
    
    /// <summary>
    ///     Датчик движения
    /// </summary>
    MotionDetector = 2,
    
    /// <summary>
    ///     Датчик двери
    /// </summary>
    DoorSensor = 3,
    
    /// <summary>
    ///     Датчик освещения
    /// </summary>
    LightSensor = 4,
    
    /// <summary>
    ///     Датчик качества воздуха
    /// </summary>
    AirQuality = 5,
}