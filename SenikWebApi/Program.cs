using DataAccess;
using Infrastructure;
using Infrastructure.Commons;
using Microsoft.EntityFrameworkCore;
using SenikWebApi;
using SenikWebApi.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();

// Add Swagger configs
builder.Services.AddSwaggerGenConfiguration();
builder.Services.AddRouting(opt => opt.LowercaseUrls = true);

// Bind AppConfiguration from configuration
var config = builder.Configuration.Get<AppConfiguration>();
builder.Configuration.Bind(config);
builder.Services.AddSingleton(config!);

// Add DB Context
//builder.Services.AddDbContext<AppDBContext>(opt => opt.UseSqlServer(config.ConnectionStrings.DefaultDB));

// Add jwt configuration
builder.Services.AddJWTConfiguration(config!.JwtConfiguration.SecretKey);

// Add DIs
builder.Services.AddDaoDIs();
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

//// Initialize data for DB
//SeedDatabase();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

//void SeedDatabase()
//{
//    using (var scope = app.Services.CreateScope())
//    {
//        var services = scope.ServiceProvider;
//        try
//        {
//            var context = services.GetRequiredService<AppDBContext>();
//            context.Database.EnsureCreated(); // create database if not exist, add table if not has any            
//        }
//        catch (Exception ex)
//        {
//            app.Logger.LogError(ex, "An error occurred when creating the DB.");
//        }
//    }
//}