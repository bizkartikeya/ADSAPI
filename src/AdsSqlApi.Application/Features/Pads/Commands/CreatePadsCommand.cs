using System;
using MediatR;

namespace AdsSqlApi.Application.Features.Pads.Commands
{
    public sealed class CreatePadsCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
