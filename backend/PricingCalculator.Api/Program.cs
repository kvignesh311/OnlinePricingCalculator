using Microsoft.EntityFrameworkCore;
using PricingCalculator.Api.Extensions;
using PricingCalculator.Api.Middleware;
using PricingCalculator.Infrastructure.Data;
using PricingCalculator.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.UseCors("AllowFrontend");

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapApiEndpoints();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PricingDbContext>();

    db.Database.Migrate();

}

app.Run();