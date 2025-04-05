using Microsoft.EntityFrameworkCore;

using System.Text.RegularExpressions;

using Task1.Dto;
using Task1.EF.Contexts;
using Task1.EF.Models;

namespace Task1.EF.Repository;

public class DataRepository(IDbContextFactory<DataContext> dbContextFactory)
{
    public async Task<IEnumerable<FullDataDto>> GetDataAsync(FilterDto filter)
    {
        await using var context = await dbContextFactory.CreateDbContextAsync();

        var query = context.Data.AsQueryable();

        if (filter.Id.HasValue)
        {
            query = query.Where(q => q.Id == filter.Id);
        }

        if (filter.Code.HasValue)
        {
            query = query.Where(q => q.Code == filter.Code);
        }

        if (!string.IsNullOrEmpty(filter.Value))
        {
            query.Where(q => q.Value == filter.Value);
        }

        return query.Select(q => new FullDataDto(q.Id, q.Code, q.Value)).ToList();
    }

    public async Task AddDataAsync(IEnumerable<DataDto> dtos)
    {
        var models = dtos.OrderBy(d => d.Code).Select(d => new DataModel() { Code = d.Code, Value = d.Value });

        await using var context = await dbContextFactory.CreateDbContextAsync();

        var strategy = context.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            await using var tr = await context.Database.BeginTransactionAsync();

            await context.Data.ExecuteDeleteAsync();

            await context.AddRangeAsync(models);

            await context.SaveChangesAsync();
            await tr.CommitAsync();
        });
    }
}
