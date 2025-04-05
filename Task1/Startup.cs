using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using System.Text.Json.Serialization;

using Task1.EF.Contexts;
using Task1.EF.Repository;
using NLog.Web;

namespace Task1;

public class Startup
{
    public async Task ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Host.UseNLog(new NLogAspNetCoreOptions { ReplaceLoggerFactory = true });

        var services = builder.Services;

        Action<JsonOptions> jsonOptions = options =>
        {
            options.JsonSerializerOptions.WriteIndented = false;
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString;
        };
        services.AddControllers().AddJsonOptions(jsonOptions);

        string connection = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddPooledDbContextFactory<DataContext>(options => options.UseSqlServer(connection));

        builder.Services.AddScoped<DataRepository>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
