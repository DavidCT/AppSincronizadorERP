using AppSincronizadorERP.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

Configure(app, app.Environment);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // Add services to the container.
    services.AddControllers();
    services.AddEndpointsApiExplorer();

    services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "API Sincronizador ERP",
            Version = "v1",
            Description = "Documentación de mi API con ejemplos claros.",
            Contact = new OpenApiContact
            {
                Name = "David Cuervo Tuñón",
                Email = "david@ngi.es",
                Url = new Uri("https://tuwebsite.com")
            }
        });
    });

    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("CadenaConexion")));

    services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
    });

     Log.Logger = new LoggerConfiguration()
        .WriteTo.Console() 
        .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();

    builder.Host.UseSerilog();
}

void Configure(WebApplication app, IWebHostEnvironment env)
{
    // Configure the HTTP request pipeline.
    if (env.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseReDoc(options =>
        {
            options.RoutePrefix = "documentacion";
            options.SpecUrl = "/swagger/v1/swagger.json";
            options.DocumentTitle = "API ReDoc Documentation";
            options.ExpandResponses("200,201");
            options.HideDownloadButton();
            options.HideHostname();
            options.RequiredPropsFirst();
            options.NoAutoAuth();
        });

    }
    app.UseHttpsRedirection();
    app.UseCors("AllowAll");
    app.UseAuthorization();
    app.MapControllers();
}


