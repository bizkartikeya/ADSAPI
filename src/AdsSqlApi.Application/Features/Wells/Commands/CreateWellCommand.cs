using System;
using MediatR;

namespace AdsSqlApi.Application.Features.Wells.Commands
{
    public sealed class CreateWellCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
