using BudganServices.Services.ColumnsMapping;
using Microsoft.Extensions.DependencyInjection;

namespace BudganServices;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBudganServices(this IServiceCollection services)
    {
        services.AddScoped<IColumnsMappingService, ColumnsMappingService>();
        
        return services;
    }
}
