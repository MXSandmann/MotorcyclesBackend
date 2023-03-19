using ApplicationCore.Models.Dtos;
using ApplicationCore.Models.Entities;
using ApplicationCore.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MotorcyclesController : ControllerBase
{
    private readonly IMotorcyclesService _service;
    private readonly IMapper _mapper;

    public MotorcyclesController(IMotorcyclesService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMotorcycles()
    {
        var motorcycles = await _service.GetAll();
        return Ok(_mapper.Map<IEnumerable<MotorcycleDto>>(motorcycles));
    }

    [HttpPost]
    public async Task<IActionResult> Create(MotorcycleDto dto)
    {
        var motorcycles = await _service.Add(_mapper.Map<Motorcycle>(dto));
        return Ok(_mapper.Map<IEnumerable<MotorcycleDto>>(motorcycles));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetMotorcycleById(Guid id)
    {
        var motorcycle = await _service.Get(id);
        return Ok(_mapper.Map<MotorcycleDto>(motorcycle));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] MotorcycleDto dto)
    {
        var motorcycles = await _service.Update(_mapper.Map<Motorcycle>(dto));
        return Ok(_mapper.Map<IEnumerable<MotorcycleDto>>(motorcycles));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        var motorcycles = await _service.Remove(id);
        return Ok(_mapper.Map<IEnumerable<MotorcycleDto>>(motorcycles));
    }
}
