using AutoMapper;
using NightWatch.Contracts.Responses.SensorIngestion;
using SensorIngestion.Domain.Entities;

namespace SensorIngestion.Domain.Mapping;

/// <summary>
///     Профиль автомаппера для показания датчика
/// </summary>
public class SensorReadingProfile : Profile
{
    // Создание маппинга
    public SensorReadingProfile()
    {
        CreateMap<SensorReading, SensorReadingDescriptionResponse>();
        CreateMap<SensorReadingDescriptionResponse, SensorReading>();
    }
}