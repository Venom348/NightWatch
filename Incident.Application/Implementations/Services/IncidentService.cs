using AutoMapper;
using Incident.Application.Exceptions;
using Incident.Domain.Abstractions.Repositories;
using Incident.Domain.Abstractions.Services;
using Incident.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NightWatch.Contracts.Common.Enums;
using NightWatch.Contracts.Requests.Incident;
using NightWatch.Contracts.Responses.Incident;

namespace Incident.Application.Implementations.Services;

/// <inheritdoc cref="IIncidentService" />
public class IncidentService : IIncidentService
{
    private readonly IBaseRepository<Domain.Entities.Incident> _incidentRepository;
    private readonly IBaseRepository<ClassificationRule> _ruleRepository;
    private readonly IMapper _mapper;

    public IncidentService(IBaseRepository<Domain.Entities.Incident> incidentRepository, IBaseRepository<ClassificationRule> ruleRepository, IMapper mapper)
    {
        _incidentRepository = incidentRepository;
        _ruleRepository = ruleRepository;
        _mapper = mapper;
    }

    public async Task<List<IncidentDescriptionResponse>> GetAllIncidents(int page = 0, int limit = 20)
    {
        // Фильтрация параметров
        if (page < 0 || limit < 0 || limit > 20)
        {
            throw new IncidentException("Некорректные данные пагинации.");
        }

        // Поиск всех инцидентов
        var result = await _incidentRepository.GetAll()
            .Skip(page * limit)
            .Take(limit)
            .ToListAsync();
        
        // Возвращает список всех инцидентов
        return _mapper.Map<List<IncidentDescriptionResponse>>(result);
    }

    public async Task<IncidentDescriptionResponse> GetIncident(Guid id)
    {
        // Поиск инцидента по ID, если такого нет - выбрасывает исключение
        var result = await _incidentRepository.GetById(id);

        if (result is null)
        {
            throw new IncidentException("Инцидент с таким ID не найден. Повторите попытку.");
        }
        
        // Возвращает инцидент по ID
        return _mapper.Map<IncidentDescriptionResponse>(result);
    }

    public async Task<List<IncidentDescriptionResponse>> GetActiveIncidents(int page = 0, int limit = 20)
    {
        // Фильтрация параметров
        if (page < 0 || limit < 0 || limit > 20)
        {
            throw new IncidentException("Некорректные данные пагинации.");
        }
        
        // Поиск всех инцидентов, которые ещё не закрыты
        var result = await _incidentRepository.GetAll()
            .Where(i => i.Status != IncidentStatus.Resolved && 
                        i.Status != IncidentStatus.FalseAlarm)
            .Skip(page * limit)
            .Take(limit)
            .ToListAsync();
        
        // Возвращает все инциденты, которые не закрыты
        return _mapper.Map<List<IncidentDescriptionResponse>>(result);
    }

    public async Task<ClassificationRuleDescriptionResponse> CreateRule(PostClassificationRuleRequest request)
    {
        // Создание правила классификации с переданными данными
        var result = await _ruleRepository.Create(new ClassificationRule
        {
            TriggerSensorType = request.TriggerSensorType,
            ResultingIncidentType = request.ResultingIncidentType,
            ResultingSeverity = request.ResultingSeverity,
            Description = request.Description
        });

        // Возвращает информацию о созданном правиле
        return _mapper.Map<ClassificationRuleDescriptionResponse>(result);
    }

    public async Task<IncidentDescriptionResponse> CreateIncident(PostIncidentRequest request)
    {
        // Поиск правила по типу датчика, если такого нет - выбрасывает исключение
        var rule = await _ruleRepository.GetAll().FirstOrDefaultAsync(r => r.TriggerSensorType == request.SensorType);
        
        if (rule is null)
        {
            throw new IncidentException("Правило классификации не найдено для данного типа датчика.");
        }
        
        // Создание инцидента с переданными данными
        var result = await _incidentRepository.Create(new Domain.Entities.Incident
        {
            Type = rule.ResultingIncidentType,
            Severity = rule.ResultingSeverity,
            Status = IncidentStatus.New,
            Location = request.Location,
            CreatedAt = DateTime.UtcNow,
            ResolvedAt = null
        });
        
        // Возвращает информацию о созданном инциденте
        return _mapper.Map<IncidentDescriptionResponse>(result);
    }

    public async Task<IncidentDescriptionResponse> UpdateStatusIncident(Guid id, PatchIncidentStatusRequest request)
    {
        // Поиск инцидента по ID, если такого нет - выбрасывает исключение
        var result = await _incidentRepository.GetById(id);

        if (result is null)
        {
            throw new IncidentException("Инцидент с таким ID не найден. Повторите попытку.");
        }
        
        // Изменяет статус
        result.Status = request.Status;
        
        // Если инцидент закрыт — фиксируем время решения
        if (request.Status == IncidentStatus.Resolved)
        {
            result.ResolvedAt = DateTime.UtcNow;
        }
        
        // Обновляет инцидент
        await _incidentRepository.Update(result);
        
        // Возвращает обновлённую информацию об инциденте
        return _mapper.Map<IncidentDescriptionResponse>(result);
    }

    public async Task<IncidentDescriptionResponse> UpdateEscalateIncident(Guid id, PatchIncidentEscalateRequest request)
    {
        // Поиск инцидента по ID, если такого нет - выбрасывает исключение
        var result = await _incidentRepository.GetById(id);

        if (result is null)
        {
            throw new IncidentException("Инцидент с таким ID не найден. Повторите попытку.");
        }

        // Изменяет строгость
        result.Severity = request.Severity;
        
        // Обновляет инцидент
        await  _incidentRepository.Update(result);
        
        // Возвращает обновлённую информацию об инциденте
        return _mapper.Map<IncidentDescriptionResponse>(result);
    }
}