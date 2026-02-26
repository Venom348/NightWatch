using Microsoft.AspNetCore.Mvc;
using NightWatch.Contracts.Requests.SensorIngestion;
using SensorIngestion.Application.Exceptions;
using SensorIngestion.Domain.Abstractions.Services;

namespace SensorIngestion.Presentation.Controllers;

/// <summary>
///     Контроллер SensorIngestion
/// </summary>
[ApiController]
[Route("api/sensors")]
public class SensorIngestionController : ControllerBase
{
    private readonly ISensorIngestionService _sensorIngestionService;

    public SensorIngestionController(ISensorIngestionService sensorIngestionService)
    {
        _sensorIngestionService = sensorIngestionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int page = 0, int limit = 20)
    {
        try
        {
            var response = await _sensorIngestionService.GetAllSensors(page, limit);
            return Ok(response);
        }
        catch (SensorIngestionException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}/status")]
    public async Task<IActionResult> GetStatus(Guid id)
    {
        try
        {
            var response = await _sensorIngestionService.GetSensorStatus(id);
            return Ok(response);
        }
        catch (SensorIngestionException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateSensor([FromBody] PostSensorRequest request)
    {
        try
        {
            var response = await _sensorIngestionService.CreateSensor(request);
            return CreatedAtAction(nameof(GetStatus), new { id = response.Id }, response);
        }
        catch (SensorIngestionException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("reading")]
    public async Task<IActionResult> CreateReading([FromBody] PostSensorReadingRequest request)
    {
        try
        {
            var response  = await _sensorIngestionService.CreateReading(request);
            return Ok(response);
        }
        catch (SensorIngestionException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("{id}/resolve")]
    public async Task<IActionResult> Resolve(Guid id)
    {
        try
        {
            await _sensorIngestionService.ResolveStatus(id);
            return Ok();
        }
        catch (SensorIngestionException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("{id}/heartbeat")]
    public async Task<IActionResult> UpdateHeartbeat(Guid id)
    {
        try
        {
            await _sensorIngestionService.UpdateHeartbeat(id);
            return Ok();
        }
        catch (SensorIngestionException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}