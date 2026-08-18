using System;
using MediatR;

namespace AdsSqlApi.Application.Features.Wells.Commands
{
    public sealed class DeleteWellCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
