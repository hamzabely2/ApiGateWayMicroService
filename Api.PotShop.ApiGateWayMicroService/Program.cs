using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
//builder.Configuration.AddJsonFile("itemMicroService/color.json", optional: false, reloadOnChange: true);
//builder.Configuration.AddJsonFile("itemMicroService/material.json", optional: false, reloadOnChange: true);
//builder.Configuration.AddJsonFile("itemMicroService/category.json", optional: false, reloadOnChange: true);
//builder.Configuration.AddJsonFile("userMicroService/adress.json", optional: false, reloadOnChange: true);
//builder.Configuration.AddJsonFile("userMicroService/user.json", optional: false, reloadOnChange: true);

builder.Services.AddCors(
    options => options.AddPolicy("TestPolicy",
        policy => policy.WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod()
    )
    );

builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

app.UseAuthorization();

app.UseCors("TestPolicy");

app.MapControllers();

await app.UseOcelot();

app.Run();
