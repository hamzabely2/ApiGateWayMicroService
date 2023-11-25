using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Configuration.AddJsonFile("item.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile("color.json", optional: false, reloadOnChange: true);

builder.Configuration.AddJsonFile("userSevice.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile("OrderService.json", optional: false, reloadOnChange: true);

builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.UseOcelot();

app.Run();