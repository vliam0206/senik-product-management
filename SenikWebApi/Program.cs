using Application.Commons;
using Application.Utils;
using DataAccess;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using SenikWebApi;
using SenikWebApi.AutoMapper;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opt
    => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenConfiguration();

// Bind AppConfiguration from configuration
var config = new AppConfiguration();
builder.Configuration.Bind(config);
builder.Services.AddSingleton(config);

// Add DB Context for seeding Database
builder.Services.AddDbContext<AppDBContext>(opt => opt.UseSqlServer(config.ConnectionStrings.DefaultDB));

// Add jwt configuration
builder.Services.AddJWTConfiguration(config.JwtConfiguration.SecretKey);

// Add DIs
builder.Services.AddRepositoryDIs();
builder.Services.AddServicesDIs();

// Add DI for IHttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Add auto maper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add CORS configuration
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin() // Allow requests from any origin
            .AllowAnyHeader()
            .AllowAnyMethod();
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

// Initialize data for DB
SeedDatabase();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<AppDBContext>();
            context.Database.EnsureCreated(); // create database if not exist, add table if not has any
            DBInitializer.InitializeData(context);
        }
        catch (Exception ex)
        {
            app.Logger.LogError(ex, "An error occurred when seeding the DB.");
        }
    }
}