using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
// Add the missing using directive for Serilog
using Serilog;
using Serilog.Sinks.Console;

using CityInfo_API.Sercices;

using Serilog.Sinks.Console;

using Serilog.Sinks.RollingFile;

using Serilog.Sinks.Console;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File(new RollingFileSink("logs\\log.txt", new JsonFormatter(), null, null, null, null, RollingInterval.Day))
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);
//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();
builder.Logging.AddSerilog();

// Add the missing using directive for LocalMailService


builder.Services.AddTransient<LocalMailService>();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson()
.AddXmlDataContractSerializerFormatters();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();


app.MapControllers();



app.Run();

