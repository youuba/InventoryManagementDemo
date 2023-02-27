using InventoryManagement.Core.Interfaces;
using InventoryManagement.EF.Models;
using InventoryManagement.EF.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<InventoryManagementContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString"),
    b => b.MigrationsAssembly(typeof(InventoryManagementContext).Assembly.FullName)).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.MapControllers();

app.Run();
