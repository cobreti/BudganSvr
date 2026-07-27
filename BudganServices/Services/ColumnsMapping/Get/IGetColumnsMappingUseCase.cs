namespace BudganServices.Services.ColumnsMapping.Get;

public interface IGetColumnsMappingUseCase : IServiceUseCase
{
    bool Succeeded { get; }
    BOGetColumnsMapping GetColumnsMappingResult { get; }
}