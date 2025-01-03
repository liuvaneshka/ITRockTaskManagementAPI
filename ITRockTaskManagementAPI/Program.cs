using ITRockTaskManagementAPI.Data;
using ITRockTaskManagementAPI.Filters;
using ITRockTaskManagementAPI.Repositories;
using ITRockTaskManagementAPI.RepositoryContracts;
using ITRockTaskManagementAPI.ServiceContracts;
using ITRockTaskManagementAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ExceptionHandlingFilter>();

builder.Services.AddScoped<ApiKeyFilter>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    return new ApiKeyFilter(configuration); 
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiKeyFilter>(); 
    options.Filters.Add<ExceptionHandlingFilter>(); 
});


builder.Services.AddEndpointsApiExplorer();

// Configure Swagger to support API Key Authentication
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("ApiKey", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "API Key required for accessing the endpoints. Use 'X-API-KEY' in headers.",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "X-API-KEY",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            Array.Empty<string>() 
        }
    });
});

var app = builder.Build();

// Run migrations at startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate(); 
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization(); 
app.MapControllers();
app.Run();
