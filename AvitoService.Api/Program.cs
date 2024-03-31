using AvitoService;
using AvitoService.Assets;
using AvitoService.Core;
using AvitoService.Infrastructure.EFCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApi();
builder.Services.AddCore();
builder.Services.AddInfrastructureEfCore();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddEndpoints();

app.Run();
