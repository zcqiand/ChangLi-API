using ChangLi.Infrastructure;
using ChangLi.API.Mappers;
using ChangLi.HostApp.Services;
using Newtonsoft.Json;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using OpenIddict.Validation.AspNetCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

// Add services to the container.

services
    .AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var connectionString = configuration.GetConnectionString("ChangLiDbConnection") ?? throw new InvalidOperationException("Connection string 'ChangLiDbConnection' not found.");

services.AddDbContext<ChangLiDbContext>(options =>
{
    options.EnableSensitiveDataLogging(true);
    options.UseNpgsql(connectionString, b => b.MigrationsAssembly("ChangLi.API"));
});

services.Scan(
    scan => scan
    .FromAssemblyOf<BusinessEnterpriseCategoryService>()
    .AddClasses(classes => classes.Where(
        t => t.Name.EndsWith("Service", StringComparison.Ordinal)))
    .AsSelf()
    .WithScopedLifetime());

services.AddAutoMapper(typeof(DtoToDomainProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.ConfigureSwaggerGen(options =>
{
    options.CustomSchemaIds(x => x.FullName);
});
services.AddSwaggerGen();

services.AddOpenIddict()
    .AddValidation(options =>
    {
        options.SetIssuer(configuration["OpenIddict:IssuerUrl"]!);

        options.AddEncryptionKey(new SymmetricSecurityKey(
            Convert.FromBase64String(configuration["OpenIddict:SecurityKey"]!)));

        options.UseSystemNetHttp();

        options.UseAspNetCore();
    });

services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors();

app.MapGet("/test", (IConfiguration configuration) =>
{
    return $"{Assembly.GetExecutingAssembly().FullName};当前时间：{DateTime.Now}";
});

app.MapControllers()
    .RequireAuthorization("ApiScope");

app.Run();