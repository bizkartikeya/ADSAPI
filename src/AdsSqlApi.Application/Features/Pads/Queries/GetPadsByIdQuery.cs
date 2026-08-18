using System;
using MediatR;

namespace AdsSqlApi.Application.Features.Pads.Queries
{
    public sealed class GetPadsByIdQuery : IRequest<PadsResponse?>
    {
        public Guid Id { get; set; }
    }
}

namespace AdsSqlApi.Application.Features.Pads
{
    public sealed class PadsResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}
