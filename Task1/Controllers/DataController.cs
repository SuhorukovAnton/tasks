using Microsoft.AspNetCore.Mvc;

using Task1.Dto;
using Task1.EF.Repository;

namespace Task1.Controllers;

[ApiController]
[Route("[controller]")]
public class DataController(DataRepository dataRepository, ILogger<DataController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<FullDataDto>> GetData(FilterDto dto)
    {
        try
        {
            return await dataRepository.GetDataAsync(dto);
        }
        catch(Exception ex)
        {
            logger.LogError(ex, "get data error");
            throw;
        }
    }


    /*
    Показался очень странным формат:
    [
        {“1”: “value1”},
        {“5”: “value2”},
    ]
    code приходит как строка и формат Dictinary вместо List
     */
    [HttpPost]
    public async Task AddData(Dictionary<string, string> dictionary)
    {
        try
        {
            await dataRepository.AddDataAsync(dictionary.Select(p => new DataDto(int.Parse(p.Key), p.Value)));
        }
        catch(Exception ex)
        {
            logger.LogError(ex, "add data error");
            throw;
        }
    }
}
