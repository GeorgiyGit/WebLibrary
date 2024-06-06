using Asp.Versioning;
using Categories.Api.Extensions;
using Categories.Api.Middlewares;
using Categories.Application.MappingProfiles.Tags;
using Categories.Application.Tags.Commands;
using Categories.Domain.Interfaces;
using Categories.Domain.Services;
using Categories.Domain.Validators.Tags;
using Categories.Infrastructure;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        var connectionString = builder.Configuration.GetConnectionString("LocalDbContextConnection") ?? throw new InvalidOperationException("Connection string 'LocalDbContextConnection' not found.");

        ConfigurationManager configuration = builder.Configuration;

        builder.Services.AddDbContext<CategoriesDbContext>(x => x.UseSqlServer(connectionString, builder =>
        {
            builder.EnableRetryOnFailure(1, TimeSpan.FromSeconds(5), null);
        }));

        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = builder.Configuration.GetConnectionString("Redis");
            options.InstanceName = "CategoriesApi_";
        });

        builder.Services.AddLocalization();
        builder.Services.AddControllers();

        builder.Services.AddAutoMapper(typeof(TagMappingProfile).Assembly);
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddTag).Assembly));

        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddValidatorsFromAssembly(typeof(AddTagValidator).Assembly);

        builder.Services.AddScoped<ILanguageService, LanguageService>();
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddAuthentication();
        //builder.Services.ConfigureIdentity();
        builder.Services.ConfigureJWT(builder.Configuration);
        builder.Services.ConfigureSwagger();



        builder.Services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-Api-Version"));
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder =>
                {
                    builder.WithOrigins("https://localhost:44444", "http://localhost:4200")
                        .AllowCredentials()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseCors("AllowSpecificOrigin");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseMiddleware<ExceptionMiddleware>();

        var supportedCultures = new[]
        {
            new CultureInfo("sk-SK"),
            new CultureInfo("en-US")
        };

        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("sk-SK"),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
        });

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}