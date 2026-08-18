using System;
using MediatR;

namespace AdsSqlApi.Application.Features.Pads.Commands
{
    public sealed class DeletePadsCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
