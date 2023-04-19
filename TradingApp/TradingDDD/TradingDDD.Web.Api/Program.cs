using FluentValidation.AspNetCore;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;
using System.Net;
using TradingDDD.Application.Services.Configuration;
using TradingDDD.Application.Services.Helpers;
using TradingDDD.Infrastructure.Persistence;
using TradingDDD.Web.Api.Automapper;
using TradingDDD.Web.Api.XSSMiddleware;

var builder = WebApplication.CreateBuilder(args);

//Enabling CORS
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add DIConfiguration
DIConfiguration diConfig = new DIConfiguration(builder.Services, builder.Configuration);
diConfig.ConfigureServices();

// Add end-point controllers
builder.Services.AddControllers();
//Remove Headers
builder.WebHost.UseKestrel(options => options.AddServerHeader = false);
//Serilog
builder.WebHost.UseSerilog((Ctx, LoggerConfiguration) =>
{
    LoggerConfiguration.WriteTo.File($"./logs/{DateTime.Now.ToString("dd-MM-yyyy")}.txt")
                       .WriteTo.Email(
                            new EmailConnectionInfo
                            {
                                EnableSsl = true,
                                Port = 465,
                                FromEmail = "serilogemails@gmail.com",
                                ToEmail = "prahabroikidi-4178@yopmail.com",
                                MailServer = "smtp.gmail.com",
                                EmailSubject = "Health Checks Report:",
                                NetworkCredentials = new NetworkCredential
                                {
                                    UserName = "serilogemails@gmail.com",
                                    Password = "coche40moto"
                                }
                            },
                            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}",
                            restrictedToMinimumLevel: LogEventLevel.Information
                        );
});

// Add swagger dependencies
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HealthCheck
builder.Services.AddHealthChecks().AddMySql(builder.Configuration.GetConnectionString("DbContextConnectionString"));

//Fluent Validation
builder.Services.AddControllers().AddFluentValidation(s =>
{
    s.RegisterValidatorsFromAssemblyContaining<Program>();
    s.DisableDataAnnotationsValidation = true;
});


// HealthCheck GUI
builder.Services.AddHealthChecksUI(options =>
{
    var conn = builder.Configuration.GetConnectionString("HealthCheckUri");
    options.SetEvaluationTimeInSeconds(30); //Sets the time interval in which HealthCheck will be triggered
    options.MaximumHistoryEntriesPerEndpoint(10); //Sets the maximum number of records displayed in history
    options.AddHealthCheckEndpoint("Health Checks API", conn); //Sets the Health Check endpoint
}).AddInMemoryStorage(); //Here is the memory bank configuration


// Automapper
builder.Services.AddAutoMapper(typeof(AutoMapping));

// HttpClient
builder.Services.AddHttpClient();
// HttpContext
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Migrations
diConfig.ConfigureMigrations(builder.Services.BuildServiceProvider()).Wait();

//Seeder
SeedDataHelper.Seed(builder.Services.BuildServiceProvider()).Wait();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}
        
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
//XSS
app.UseMiddleware<AntiXssMiddleware>();

//Sets Health Check dashboard options
app.UseHealthChecks("/health", new HealthCheckOptions
{
    Predicate = p => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

//HealthCheck EndPoints
app.MapControllers();
app.MapHealthChecks("/health");
//Sets the Health Check dashboard configuration
app.UseHealthChecksUI(options => { options.UIPath = "/dashboard"; });
app.Run();
