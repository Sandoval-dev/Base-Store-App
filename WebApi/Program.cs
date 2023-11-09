using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using Presentation.ActionFilters;
using Repositories.EfCore;
using Services;
using Services.Contracts;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
    config.CacheProfiles.Add("5mins",new CacheProfile() { Duration=300});
})
    .AddCustomCsvFormatter()
    .AddXmlDataContractSerializerFormatters()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
    //.AddNewtonsoftJson();



builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter= true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureActionFilters();
builder.Services.ConfigureCors();
builder.Services.ConfigureDataShaper();
builder.Services.ConfigureHttpCacheHeaders();
builder.Services.AddCustomMediaTypes();
builder.Services.ConfigureResponseCaching();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IBookLinks, BookLinks>();
builder.Services.ConfigureVersioning();
builder.Services.ConfigureRateLimitingOptions();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();
var app = builder.Build();

var logger=app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseIpRateLimiting();
app.UseCors("CorsPolicy");
app.UseResponseCaching();
app.UseHttpCacheHeaders();
app.UseAuthorization();

app.MapControllers();

app.Run();
