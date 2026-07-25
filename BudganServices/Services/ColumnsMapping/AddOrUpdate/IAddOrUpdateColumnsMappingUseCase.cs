namespace BudganServices.Services.ColumnsMapping.AddOrUpdate;

public interface IAddOrUpdateColumnsMappingUseCase : IServiceUseCase
{
    Guid Result { get; }
}