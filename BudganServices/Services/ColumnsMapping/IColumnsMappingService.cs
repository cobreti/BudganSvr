using BudganServices.Services.ColumnsMapping.AddOrUpdate;

namespace BudganServices.Services.ColumnsMapping;

public interface IColumnsMappingService
{
    IAddOrUpdateColumnsMappingUseCase GetAddOrUpdateUseCase(BOAddOrUpdateColumnsMapping model);
}