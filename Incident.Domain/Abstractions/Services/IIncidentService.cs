using NightWatch.Contracts.Requests.Incident;
using NightWatch.Contracts.Responses.Incident;

namespace Incident.Domain.Abstractions.Services;

/// <summary>
///     Сервис для работы с инцидентами
/// </summary>
public interface IIncidentService
{
    /// <summary>
    ///     Получение всех инцидентов
    /// </summary>
    /// <param name="page">Страница для пагинации</param>
    /// <param name="limit">Лимит пагинации</param>
    /// <returns></returns>
    Task<List<IncidentDescriptionResponse>> GetAllIncidents(int page = 0, int limit = 20);
    
    /// <summary>
    ///     Получение по ID
    /// </summary>
    /// <param name="id">Идентификатор инцидента</param>
    /// <returns></returns>
    Task<IncidentDescriptionResponse> GetIncident(Guid id);
    
    /// <summary>
    ///     Получение только активных инцидентов
    /// </summary>
    /// <param name="page">Страница для пагинации</param>
    /// <param name="limit">Лимит пагинации</param>
    /// <returns></returns>
    Task<List<IncidentDescriptionResponse>> GetActiveIncidents(int page = 0, int limit = 20);
    
    /// <summary>
    ///     Создание правила классификации
    /// </summary>
    /// <param name="request">Данные для создания</param>
    /// <returns></returns>
    Task<ClassificationRuleDescriptionResponse> CreateRule(PostClassificationRuleRequest request);
    
    /// <summary>
    ///     Создание инцидента
    /// </summary>
    /// <param name="request">Данные для создания</param>
    /// <returns></returns>
    Task<IncidentDescriptionResponse> CreateIncident(PostIncidentRequest request);
    
    /// <summary>
    ///     Обновление статуса инцидента
    /// </summary>
    /// <param name="id">Идентификатор инцидента</param>
    /// <param name="request">Данные для обновления</param>
    /// <returns></returns>
    Task<IncidentDescriptionResponse> UpdateStatusIncident(Guid id, PatchIncidentStatusRequest request);
    
    /// <summary>
    ///     Обновление строгости инцидента
    /// </summary>
    /// <param name="id">Идентификатор инцидента</param>
    /// <param name="request">Данные для обновления</param>
    /// <returns></returns>
    Task<IncidentDescriptionResponse> UpdateEscalateIncident(Guid id, PatchIncidentEscalateRequest request);
}