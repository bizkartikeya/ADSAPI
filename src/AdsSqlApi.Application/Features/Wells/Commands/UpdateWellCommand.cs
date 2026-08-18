using System;
using MediatR;

namespace AdsSqlApi.Application.Features.Wells.Commands
{
    public sealed class UpdateWellCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
