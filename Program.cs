using GuitarShop.Data;
using GuitarShop.Helpers.Seeders;
using GuitarShop.Repositories.EmployeeRepository;
using GuitarShop.Repositories.InstrumentRepository;
using GuitarShop.Repositories.JobRepository;
using GuitarShop.Repositories.ShopRepository;
using GuitarShop.Repositories.UnitOfWork;
using GuitarShop.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<GuitarShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IInstrumentRepository, InstrumentRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IShopRepository, ShopRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ShopSeeder>();
builder.Services.AddScoped<JobSeeder>();
builder.Services.AddScoped<InstrumentSeeder>();
builder.Services.AddScoped<EmployeeSeeder>();
builder.Services.AddScoped<ResponsibilitySeeder>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var shopSeeder = scope.ServiceProvider.GetRequiredService<ShopSeeder>();
    var jobSeeder = scope.ServiceProvider.GetRequiredService<JobSeeder>();
    var instrumentSeeder = scope.ServiceProvider.GetRequiredService<InstrumentSeeder>();
    var employeeSeeder = scope.ServiceProvider.GetRequiredService<EmployeeSeeder>();
    var responsibilitySeeder = scope.ServiceProvider.GetRequiredService<ResponsibilitySeeder>();

    shopSeeder.SeedInitialShops();
    jobSeeder.SeedInitialJobs();
    instrumentSeeder.SeedInitialInstruments();
    employeeSeeder.SeedInitialEmployees();
    responsibilitySeeder.SeedInitialResponsibilities();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
