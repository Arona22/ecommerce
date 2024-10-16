using Microsoft.EntityFrameworkCore;
using ProductCatalogApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

// Register the ProductCatalogContext to use PostgreSQL
builder.Services.AddDbContext<ProductCatalogContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add controllers to the container
builder.Services.AddControllers();

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
