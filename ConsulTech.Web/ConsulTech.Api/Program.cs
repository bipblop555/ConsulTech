using ConsulTech.Core.Context;
using ConsulTech.Core.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowDashboard", policy =>
    {
        policy.WithOrigins("https://localhost:7298", "http://localhost:5062") // Ajoutez l'origine de votre front-end
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContext<ConsultTechContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConsultTechDbContext")));
builder.Services.AddOpenApi();
builder.Services.AddCoreServices();

var app = builder.Build();
app.UseCors("AllowDashboard");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
