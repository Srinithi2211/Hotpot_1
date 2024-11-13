using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add DbContext configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register your repositories and implementations
builder.Services.AddScoped<IMenu, MenuImpl>();
builder.Services.AddScoped<ICart, CartImpl>();
builder.Services.AddScoped<IDashboardUser, DashboardUserImpl>();
builder.Services.AddScoped<IDashboardRestaurant, DashboardRestaurantImpl>();
builder.Services.AddScoped<IOrder, OrderImpl>();

// Add controllers
builder.Services.AddControllers();

// Add Swagger/OpenAPI for documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Map the controllers to the request pipeline
app.MapControllers();

app.Run();
