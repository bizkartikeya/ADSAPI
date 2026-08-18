using System;

namespace AdsSqlApi.Application.DTOs.Wells
{
    public sealed class WellRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
