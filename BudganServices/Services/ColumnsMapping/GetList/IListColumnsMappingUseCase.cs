namespace BudganServices.Services.ColumnsMapping.GetList;

public interface IListColumnsMappingUseCase : IServiceUseCase
{
    List<ListColumnsMapping> GetListResult { get; }
}
