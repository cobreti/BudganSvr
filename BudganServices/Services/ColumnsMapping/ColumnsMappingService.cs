using BudganInfra.Repositories.ColumnsMapping;
using BudganServices.Services.ColumnsMapping.AddOrUpdate;

namespace BudganServices.Services.ColumnsMapping;

internal class ColumnsMappingService : IColumnsMappingService
{
    private readonly IColumnsMappingRepository _columnsMappingRepository;
    
    public ColumnsMappingService(IColumnsMappingRepository columnsMappingRepository)
    {
        _columnsMappingRepository = columnsMappingRepository;
    }

    public IAddOrUpdateColumnsMappingUseCase GetAddOrUpdateUseCase(BOAddOrUpdateColumnsMapping model)
    {
        return new AddOrUpdateColumnsMappingUseCase(this._columnsMappingRepository, model);
    }
}
