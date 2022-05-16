using Domain.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Extensions;

EnvironmentSettings.FetchEnvironmentVariables();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContextFactory<HDContext>(options => options.UseNpgsql(EnvironmentSettings.PostgresConnectionString!));

builder.Services.AddPersistence();
builder.Services.AddDomain();

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

app.UseCors(policyBuilder => policyBuilder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();