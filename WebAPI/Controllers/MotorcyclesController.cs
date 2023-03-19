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
        var created = await _service.Add(_mapper.Map<Motorcycle>(dto));
        var motorcycles = await _service.GetAll();
        return Ok(_mapper.Map<IEnumerable<MotorcycleDto>>(motorcycles));
        //return Ok(created);
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
        var updated = await _service.Update(_mapper.Map<Motorcycle>(dto));
        var motorcycles = await _service.GetAll();
        return Ok(_mapper.Map<IEnumerable<MotorcycleDto>>(motorcycles));
        //return Ok(_mapper.Map<MotorcycleDto>(updated));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        await _service.Remove(id);
        var motorcycles = await _service.GetAll();
        return Ok(_mapper.Map<IEnumerable<MotorcycleDto>>(motorcycles));
        //return Ok();
    }
}
