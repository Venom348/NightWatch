using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NightWatch.Contracts.Common.Enums;
using NightWatch.Contracts.Requests.SensorIngestion;
using NightWatch.Contracts.Responses.SensorIngestion;
using SensorIngestion.Application.Exceptions;
using SensorIngestion.Domain.Abstractions.Repositories;
using SensorIngestion.Domain.Abstractions.Services;
using SensorIngestion.Domain.Entities;

namespace SensorIngestion.Application.Implementations.Services;

/// <inheritdoc cref="ISensorIngestionService"/>
public class SensorIngestionService : ISensorIngestionService
{
    private readonly IBaseRepository<Sensor> _sensorRepository;
    private readonly IBaseRepository<SensorReading> _sensorReadingRepository;
    private readonly IMapper _mapper;

    public SensorIngestionService(IBaseRepository<Sensor> sensorRepository, IBaseRepository<SensorReading> sensorReadingRepository, IMapper mapper)
    {
        _sensorRepository = sensorRepository;
        _sensorReadingRepository = sensorReadingRepository;
        _mapper = mapper;   
    }

    public async Task<List<SensorDescriptionResponse>> GetAllSensors(int page = 0, int limit = 20)
    {
        // Фильтрация параметров
        if (page <= 0 || limit < 0 || limit > 20)
        {
            throw new SensorIngestionException("Некорректные данные пагинации.");
        }

        // Поиск всех датчиков
        var result = await _sensorRepository.GetAll()
            .Skip(page * limit)
            .Take(limit)
            .ToListAsync();
        
        // Возвращает список всех датчиков
        return _mapper.Map<List<SensorDescriptionResponse>>(result);
    }

    public async Task<SensorStatusResponse> GetSensorStatus(Guid id)
    {
        // Поиск датчика по ID, если такого нет - выбрасывает исключение
        var result = await _sensorRepository.GetById(id);

        if (result is null)
        {
            throw new SensorIngestionException("Датчик с таким ID не найден. Повторите попытку");
        }
        
        // Возвращает статус датчика
        return _mapper.Map<SensorStatusResponse>(result);
    }

    public async Task<SensorDescriptionResponse> CreateSensor(PostSensorRequest request)
    {
        // Создание датчика
        var result = await _sensorRepository.Create(new Sensor
        {
            Type =  request.Type,
            Location =  request.Location,
            Status = SensorStatus.Offline,
            LastHeartbeat = null
        });
        
        // Возвращает информацию о датчике
        return _mapper.Map<SensorDescriptionResponse>(result);
    }

    public async Task<SensorReadingDescriptionResponse> CreateReading(PostSensorReadingRequest request)
    {
        // Поиск датчика по ID, если такого нет - выбрасывает исключение
        var sensor = await _sensorRepository.GetById(request.SensorId);
        
        if (sensor is null)
        {
            throw new SensorIngestionException("Датчик с таким ID не найден. Повторите попытку");
        }

        // Если Payload пустой — датчик неисправен
        if (string.IsNullOrEmpty(request.Payload))
        {
            sensor.Status = SensorStatus.Malfunction;
            await _sensorRepository.Update(sensor);
            
            throw new SensorIngestionException("Датчик шлёт некорректные данные");
        }
        
        // Создание показания датчика
        var result = await _sensorReadingRepository.Create(new SensorReading
        {
            SensorId =  request.SensorId,
            Type =  request.Type,
            Payload =  request.Payload,
            Location =  request.Location,
            Timestamp =  DateTime.UtcNow
        });
        
        // Возвращает данные показания датчика
        return _mapper.Map<SensorReadingDescriptionResponse>(result);
    }

    public async Task ResolveStatus(Guid id)
    {
        // Поиск датчика по ID, если такого нет - выбрасывает исключение
        var result = await _sensorRepository.GetById(id);

        if (result is null)
        {
            throw new SensorIngestionException("Датчик с таким ID не найден. Повторите попытку");
        }
        
        // Ручное восстановление доступно только для Malfunction и Maintenance
        if (result.Status != SensorStatus.Malfunction && 
            result.Status != SensorStatus.Maintenance)
        {
            throw new SensorIngestionException("Датчик не требует ручного восстановления.");
        }

        result.Status = SensorStatus.Online;
        
        // Обновляет датчик
        await _sensorRepository.Update(result);
    }

    public async Task UpdateHeartbeat(Guid id)
    {
        // Поиск датчика по ID, если такого нет - выбрасывает исключение
        var result = await _sensorRepository.GetById(id);

        if (result is null)
        {
            throw new SensorIngestionException("Датчик с таким ID не найден. Повторите попытку");
        }
        
        result.LastHeartbeat = DateTime.UtcNow;
        
        // Malfunction и Maintenance сбрасываются только вручную
        if (result.Status != SensorStatus.Malfunction && 
            result.Status != SensorStatus.Maintenance)
        {
            result.Status = SensorStatus.Online;
        }
        
        // Обновляет датчик
        await _sensorRepository.Update(result);
    }
}