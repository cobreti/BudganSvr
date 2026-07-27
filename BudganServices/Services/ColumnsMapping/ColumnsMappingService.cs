using BudganInfra.Repositories.ColumnsMapping;
using BudganServices.Services.ColumnsMapping.AddOrUpdate;
using BudganServices.Services.ColumnsMapping.GetList;

namespace BudganServices.Services.ColumnsMapping;

internal class ColumnsMappingService : IColumnsMappingService
{
    private readonly IColumnsMappingRepository _columnsMappingRepository;
    
    public ColumnsMappingService(IColumnsMappingRepository columnsMappingRepository)
    {
        _columnsMappingRepository = columnsMappingRepository;
    }

    public IAddOrUpdateColumnsMappingUseCase AddOrUpdateUseCase(BOAddOrUpdateColumnsMapping model)
    {
        return new AddOrUpdateColumnsMappingUseCase(this._columnsMappingRepository, model);
    }

    public IListColumnsMappingUseCase ListColumnsMappingUseCase()
    {
        return new ListColumnsMappingUseCase(this._columnsMappingRepository);
    }
}
