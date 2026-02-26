using NightWatch.Contracts.Requests.SensorIngestion;
using NightWatch.Contracts.Responses.SensorIngestion;

namespace SensorIngestion.Domain.Abstractions.Services;

/// <summary>
///     Сервис для работы с датчиками
/// </summary>
public interface ISensorIngestionService
{
    /// <summary>
    ///     Получение всех датчиков
    /// </summary>
    /// <param name="page">Страница для пагинации</param>
    /// <param name="limit">Лимит пагинации</param>
    /// <returns></returns>
    Task<List<SensorDescriptionResponse>> GetAllSensors(int page = 0, int limit = 20);
    
    /// <summary>
    ///     Получение статуса датчика
    /// </summary>
    /// <param name="id">Идентификатор датчика</param>
    /// <returns></returns>
    Task<SensorStatusResponse> GetSensorStatus(Guid id);
    
    /// <summary>
    ///     Создание датчика
    /// </summary>
    /// <param name="request">Данные для отправки</param>
    /// <returns></returns>
    Task<SensorDescriptionResponse> CreateSensor(PostSensorRequest request);
    
    /// <summary>
    ///     Создание показания датчика
    /// </summary>
    /// <param name="request">Данные для отправки</param>
    /// <returns></returns>
    Task<SensorReadingDescriptionResponse> CreateReading(PostSensorReadingRequest request);
    
    /// <summary>
    ///     Перевод датчика в статус Online после устранения неисправности
    /// </summary>
    /// <param name="id">Идентификатор датчика</param>
    /// <returns></returns>
    Task ResolveStatus(Guid id);
    
    /// <summary>
    ///     Обновление датчика
    /// </summary>
    /// <param name="id">Идентификатор датчика</param>
    /// <returns></returns>
    Task UpdateHeartbeat(Guid id);
}