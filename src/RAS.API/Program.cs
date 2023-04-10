using Autofac;
using Autofac.Extensions.DependencyInjection;
using RAS.Core;
using RAS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog.Web;
using RAS.Infrastructure.Data;
using RAS.API;
using RAS.API.Extensions;
using RAS.API.Middlewares;
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using RAS.API.Converters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using RAS.API.Configuration;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Utils.Library.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseNLog(new NLogAspNetCoreOptions
{
    RemoveLoggerFactoryFilter = false,
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("RASDatabase");
builder.Services.AddAppDbContext(connectionString);

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddHttpClient();

builder.Services.AddCors();

builder.Services
    .AddControllers(x =>
    {
        x.Filters.Add<TransactionPerRequestFilter>();
        x.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build()));
    })
    .AddJsonOptions(x => x.JsonSerializerOptions.Converters.AddConverters())
    .AddFluentValidation(x =>
    {
        x.RegisterValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly(), typeof(CoreDIModule).Assembly });
    }); ;

builder.Services.Configure<MvcOptions>(options =>
{
    TypeDescriptor.AddAttributes(typeof(DateOnly), new TypeConverterAttribute(typeof(DateOnlyTypeConverter)));
});

builder.Services.AddSingleton<IConfigureOptions<JwtBearerOptions>, ConfigureJwtBearerOptions>();
builder.Services.AddAuthentication()
    .AddJwtBearer();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RAS.API", Version = "v1" });
    c.EnableAnnotations();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme {
            Reference = new OpenApiReference {
                Type = ReferenceType.SecurityScheme,
                Id = JwtBearerDefaults.AuthenticationScheme
            }
        },
        new string[] {}
    }
    });
});

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new CoreDIModule());
    containerBuilder.RegisterModule(new InfrastructureDIModule());
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.UseDeveloperExceptionPage();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseRouting();


app.MapControllers();

MigrateDb(app);

app.Run();

static void MigrateDb(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<DatabaseContext>();
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred migrating the database.");
        }
    }
}
