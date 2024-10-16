using Microsoft.EntityFrameworkCore;
using OrderManagementApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

// Register the DbContext to use PostgreSQL
builder.Services.AddDbContext<OrderManagementContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add controllers
builder.Services.AddControllers();

// Add Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Optionally, configure CORS if needed (optional, depending on the front-end setup)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS (optional, remove if not needed)
app.UseCors();

app.UseAuthorization();

// Map the API endpoints to controllers
app.MapControllers();

app.Run();
