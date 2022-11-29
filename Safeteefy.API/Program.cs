using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Safeteefy.API.Safeteefy.Domain.Mapping;
using Safeteefy.API.Safeteefy.Domain.Repositories;
using Safeteefy.API.Safeteefy.Domain.Services;
using Safeteefy.API.Safeteefy.Persistence.Repositories;
using Safeteefy.API.Safeteefy.Services;
using Safeteefy.API.Shared.Domain.Repositories;
using Safeteefy.API.Shared.Persistence.Contexts;
using Safeteefy.API.Shared.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Safeteefy API",
        Description = "Safeteefy RESTful API",
    });
    options.EnableAnnotations();
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());
        
        
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IGuardianRepository, GuardianRepository>();
builder.Services.AddScoped<IGuardianService, GuardianService>();
builder.Services.AddScoped<IUrgencyRepository, UrgencyRepository>();
builder.Services.AddScoped<IUrgencyService, UrgencyService>();




builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile)
);

var app = builder.Build();
    
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context?.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
    
app.UseHttpsRedirection();
app.MapControllers();

app.Run();