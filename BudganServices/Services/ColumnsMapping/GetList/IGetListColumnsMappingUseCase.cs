namespace BudganServices.Services.ColumnsMapping.GetList;

public interface IGetListColumnsMappingUseCase : IServiceUseCase
{
    List<BOGetListColumnsMapping> GetListResult { get; }
}
