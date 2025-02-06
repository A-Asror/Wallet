using System.Globalization;
using System.Reflection;
using FluentValidation;
using FluentValidation.Resources;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using VirtualWallet.Application;
using VirtualWallet.Infrastructure;


namespace VirtualWallet.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Добавляем Swagger
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
        builder.Services.AddSwaggerGen();

        // Настраиваем поддержку локализации
        builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
        // Подключаем FluentValidation
        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        ValidatorOptions.Global.LanguageManager = new LanguageManager();
        builder.Services.AddControllers().AddDataAnnotationsLocalization();
        // Middleware для определения языка из заголовка
        var supportedCultures = new[] { "en", "ru" };
        var localizationOptions = new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("en"),
            SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList(),
            // SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList()
        };
        // Добавляем версионирование
        builder.Services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
        });

        builder.Services.AddApplication();
        builder.Services.AddServices(); 
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRequestLocalization(localizationOptions);
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}