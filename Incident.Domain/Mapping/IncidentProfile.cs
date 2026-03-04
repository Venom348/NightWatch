using AutoMapper;
using NightWatch.Contracts.Responses.Incident;

namespace Incident.Domain.Mapping;

/// <summary>
///     Профиль автомаппера для инцидента
/// </summary>
public class IncidentProfile : Profile
{
    // Создание маппинга
    public IncidentProfile()
    {
        CreateMap<Entities.Incident, IncidentDescriptionResponse>();
        CreateMap<IncidentDescriptionResponse, Entities.Incident>();
    }
}