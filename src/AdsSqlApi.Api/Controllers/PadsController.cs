using AdsSqlApi.Application.DTOs.Pads;
using AdsSqlApi.Application.Features.Pads.Commands;
using AdsSqlApi.Application.Features.Pads.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdsSqlApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class PadsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PadsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _mediator.Send(new GetPadsByIdQuery { Id = id });
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PadsRequestDto dto)
    {
        var id = await _mediator.Send(new CreatePadsCommand { Name = dto.Name, Code = dto.Code, IsActive = dto.IsActive });
        return CreatedAtAction(nameof(Get), new { id }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] PadsRequestDto dto)
    {
        await _mediator.Send(new UpdatePadsCommand { Id = id, Name = dto.Name, Code = dto.Code, IsActive = dto.IsActive });
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeletePadsCommand { Id = id });
        return NoContent();
    }
}
