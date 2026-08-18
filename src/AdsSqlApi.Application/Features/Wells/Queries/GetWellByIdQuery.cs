using System;
using MediatR;
using AdsSqlApi.Application.Features.Wells.Responses;

namespace AdsSqlApi.Application.Features.Wells.Queries
{
    public sealed class GetWellByIdQuery : IRequest<WellResponse?>
    {
        public Guid Id { get; set; }
    }
}

namespace AdsSqlApi.Application.Features.Wells.Responses
{
    public sealed class WellResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}
