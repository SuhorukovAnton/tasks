using Microsoft.AspNetCore.Mvc;

namespace Task1.Dto;

public class FilterDto
{
    [FromQuery]
    public int? Id { get; set; }
    [FromQuery]
    public int? Code { get; set; }
    [FromQuery]
    public string? Value { get; set; }
}
