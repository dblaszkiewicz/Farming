using MediatR;
using Farming.Infrastructure;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Config.ReadConfiguration;
using Farming.Api.Middleware;
using NLog.Web;
using Farming.Application;
using Microsoft.OpenApi.Models;
using Farming.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration Configuration = builder.Configuration;

// todo - get assembly by name?
builder.Services.AddMediatR(typeof(IReadConfiguration));
builder.Services.AddMediatR(typeof(GetAllPlantsQuery));

builder.Services.AddInfrastructure(Configuration);
builder.Services.AddApplication();
builder.Services.AddApi();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Farming.Api", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] { }
    }});
});

builder.Host.UseNLog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<MultiTenantServiceMiddleware>();

app.UseMiddleware<ErrorMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());

app.UseAuthorization();

app.UseAuthentication();

app.UseMiddleware<JwtMiddleware>();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.CreateDatabase();

app.Run();
