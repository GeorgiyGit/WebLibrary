using Asp.Versioning;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using VirtualPeople.Api.Extensions;
using VirtualPeople.Api.Middlewares;
using VirtualPeople.Application.MappingProfiles.People;
using VirtualPeople.Application.People.BookAuthors.CustomerBookAuthors.Commands;
using VirtualPeople.Domain.Interfaces;
using VirtualPeople.Domain.Resources.Localization;
using VirtualPeople.Domain.Services;
using VirtualPeople.Domain.Validators.People.BookAuthors;
using VirtualPeople.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("LocalDbContextConnection") ?? throw new InvalidOperationException("Connection string 'LocalDbContextConnection' not found.");

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<VirtualPeopleDbContext>(x => x.UseSqlServer(connectionString, builder =>
{
    builder.EnableRetryOnFailure(1, TimeSpan.FromSeconds(5), null);
}));

builder.Services.AddLocalization();
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(BookAuthorMappingProfiles).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddBookAuthor).Assembly));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(typeof(AddBookAuthorValidator).Assembly);

builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
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

var langCodes = Languages.GetAll();
var supportedCultures = new List<CultureInfo>(langCodes.Count);

foreach(var langCode in langCodes)
{
    supportedCultures.Add(new CultureInfo(langCode));
}

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(Languages.SK),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
