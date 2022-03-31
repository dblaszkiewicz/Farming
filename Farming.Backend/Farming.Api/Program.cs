using MediatR;
using Farming.Infrastructure;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Config.ReadConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration Configuration = builder.Configuration;

// todo - get assembly by name?
builder.Services.AddMediatR(typeof(IReadConfiguration));
builder.Services.AddMediatR(typeof(GetAllPlantsQuery));

builder.Services.AddInfrastructure(Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
