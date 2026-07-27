using BudganServices.Services.ColumnsMapping.AddOrUpdate;
using BudganServices.Services.ColumnsMapping.Get;
using BudganServices.Services.ColumnsMapping.GetList;

namespace BudganServices.Services.ColumnsMapping;

public interface IColumnsMappingService
{
    IAddOrUpdateColumnsMappingUseCase AddOrUpdateUseCase(BOAddOrUpdateColumnsMapping model);
    IListColumnsMappingUseCase  ListColumnsMappingUseCase();
    IGetColumnsMappingUseCase GetColumnsMappingUseCase(Guid id);
}