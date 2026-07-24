using BudganInfra.DBContext;
using BudganInfra.Repositories.ColumnsMapping;
using BudganInfra.Repositories.UserAccount;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BudganInfra;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                sqlServerOptions => sqlServerOptions.MigrationsAssembly(typeof(ServiceCollectionExtensions).Assembly.FullName)));

        services.AddScoped<IUserAccountRepository, UserAccountRepository>();
        services.AddScoped<IColumnsMappingRepository, ColumnsMappingRepository>();
        
        return services;
    }
}
