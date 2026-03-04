using AutoMapper;
using Incident.Domain.Entities;
using NightWatch.Contracts.Responses.Incident;

namespace Incident.Domain.Mapping;

/// <summary>
///     Профиль автомаппера для правила классификации
/// </summary>
public class ClassificationRuleProfile : Profile
{
    // Создание маппинга
    public ClassificationRuleProfile()
    {
        CreateMap<ClassificationRule, ClassificationRuleDescriptionResponse>();
        CreateMap<ClassificationRuleDescriptionResponse, ClassificationRule>();
    }
}