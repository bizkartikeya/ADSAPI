using System;

namespace AdsSqlApi.Application.DTOs.Pads
{
    public sealed class PadsRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
