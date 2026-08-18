using AdsSqlApi.Application.DTOs.Wells;
using AdsSqlApi.Application.Features.Wells.Commands;
using AdsSqlApi.Application.Features.Wells.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdsSqlApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class WellsController : ControllerBase
{
    private readonly IMediator _mediator;

    public WellsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _mediator.Send(new GetWellByIdQuery { Id = id });
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] WellRequestDto dto)
    {
        var id = await _mediator.Send(new CreateWellCommand { Name = dto.Name, Code = dto.Code, IsActive = dto.IsActive });
        return CreatedAtAction(nameof(Get), new { id }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] WellRequestDto dto)
    {
        await _mediator.Send(new UpdateWellCommand { Id = id, Name = dto.Name, Code = dto.Code, IsActive = dto.IsActive });
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteWellCommand { Id = id });
        return NoContent();
    }
}
