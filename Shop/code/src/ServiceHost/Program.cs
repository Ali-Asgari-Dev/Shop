using ServiceHost;
using Shop.Domain.Models.Orders;
using Shop.Domain.Services;
using Shop.Infrastructure.DomainServices;
using Shop.Infrastructure.Persistence.Sql.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.AddDatabase();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUnitOfDiscountCalculatorService, UnitOfDiscountCalculatorService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

// app.UseHttpsRedirection();

app.Run();
