namespace BudganServices.Services.ColumnsMapping.GetList;

public interface IListColumnsMappingUseCase : IServiceUseCase
{
    List<BOListColumnsMapping> GetListResult { get; }
}
