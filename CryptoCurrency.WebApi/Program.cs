using System.Reflection;
using CryptoCurrency.WebApi.Configurations;
using CryptoCurrency.WebApi.Filters;
using CryptoCurrency.WebApi.Services.CoinMarketCap;
using FluentValidation;
using FluentValidation.AspNetCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Adding CoinMarketCap (cmc) Config
var cmcConf = builder.Configuration.GetSection(CoinMarketCapConfig.AppSettingName).Get<CoinMarketCapConfig>();
builder.Services.AddSingleton<ICoinMarketCapConfig>(cmcConf ?? throw new ArgumentNullException());

// Adding validation for request models
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddFluentValidationAutoValidation();

// Adding HttpClient
builder.Services.AddHttpClient();

// Adding services
builder.Services.AddScoped<ICmcServices, CmcServices>();

// Adding Typed HttpClient
builder.Services.ConfigCmcHttpClient(cmcConf);

builder.Services.AddControllers(config =>
{
    // Adding filters to be applied in each api input
    config.Filters.Add(typeof(ExceptionHandlerAttribute));
    config.Filters.Add(typeof(ValidateModelAttribute));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "CryptoCurrency");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
