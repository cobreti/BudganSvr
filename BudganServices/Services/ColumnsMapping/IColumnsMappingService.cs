using BudganServices.Services.ColumnsMapping.AddOrUpdate;
using BudganServices.Services.ColumnsMapping.GetList;

namespace BudganServices.Services.ColumnsMapping;

public interface IColumnsMappingService
{
    IAddOrUpdateColumnsMappingUseCase AddOrUpdateUseCase(BOAddOrUpdateColumnsMapping model);
    IGetListColumnsMappingUseCase  GetListColumnsMappingUseCase(BOGetListColumnsMapping model);
}