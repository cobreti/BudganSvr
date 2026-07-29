using BudganServices.UseCases.Account;
using BudganServices.UseCases.ColumnsMapping;
using Microsoft.Extensions.DependencyInjection;

namespace BudganServices;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBudganServices(this IServiceCollection services)
    {
        services.AddScoped<IColumnsMappingUseCaseFactory, ColumnsMappingUseCaseFactory>();
        services.AddScoped<IAccountUseCaseFactory, AccountUseCaseFactory>();

        return services;
    }
}
