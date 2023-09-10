using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using SalesOrder.Api.Data;
using SalesOrder.Api.Repositories.Implementations;
using SalesOrder.Api.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<SalesOrderDBContext>
    (option=>option.UseSqlServer(builder.Configuration
    .GetConnectionString("SDDbCon"))
    );

builder.Services.AddScoped<IStateInfoRepository, StateInfoRepository>();
builder.Services.AddScoped<ISaleOrderRepository, SaleOrderRepository>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy=>policy.WithOrigins
("http://localhost:7033", "https://localhost:7033", "https://localhost:444")
.AllowAnyMethod()
.WithHeaders(HeaderNames.ContentType)
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
