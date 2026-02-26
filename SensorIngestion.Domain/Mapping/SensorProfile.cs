using AutoMapper;
using NightWatch.Contracts.Responses.SensorIngestion;
using SensorIngestion.Domain.Entities;

namespace SensorIngestion.Domain.Mapping;

/// <summary>
///     Профиль автомаппера для датчика
/// </summary>
public class SensorProfile : Profile
{
    // Создание маппинга
    public SensorProfile()
    {
        CreateMap<Sensor, SensorDescriptionResponse>();
        CreateMap<SensorDescriptionResponse, Sensor>();
    }
}