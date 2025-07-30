using EagleBank.Application.Services;
using EagleBank.Domain.Repositories;
using EagleBank.Infrastructure;
using EagleBank.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var connectionString = builder.Configuration.GetConnectionString("MySqlServer");

builder.Services.AddScoped<IUserService, UserService>()
    .AddScoped<IUserRepository, UserRepository>()
    .AddDbContext<IDbContext, EagleBankDbContext>((options) =>
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<EagleBankDbContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
app.Run();