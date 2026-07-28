namespace BudganServices.UseCases.ColumnsMapping.GetList;

public interface IListColumnsMappingUseCase : IBaseUseCase
{
    List<BOListColumnsMapping> GetListResult { get; }
}
