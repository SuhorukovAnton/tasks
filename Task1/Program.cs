using Task1;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup();
await startup.ConfigureServices(builder);

var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();
