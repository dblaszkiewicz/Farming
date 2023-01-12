using MediatR;
using Farming.Infrastructure;
using Farming.Api.Middleware;
using NLog.Web;
using Farming.Application;
using Farming.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
        optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddMediatR(typeof(IMediatRApplicationMarker));
builder.Services.AddMediatR(typeof(IMediatRInfrastructureMarker));

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddApi();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

builder.Host.UseNLog();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

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
