using EagleBank.Application.Services;
using EagleBank.Domain.Repositories;
using EagleBank.Infrastructure;
using EagleBank.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EagleBank.Api.Extensions;

public static class DependencyInjection
{
    public static void AddDependencies(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("MySqlServer");
        builder.Services
            .AddScoped<IUserService, UserService>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IAccountService, AccountService>()
            .AddScoped<IAccountRepository, AccountRepository>()
            .AddHttpContextAccessor()
            .AddScoped<ICurrentUserService, CurrentUserService>()
            .AddDbContext<IDbContext, EagleBankDbContext>((options) =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }
}