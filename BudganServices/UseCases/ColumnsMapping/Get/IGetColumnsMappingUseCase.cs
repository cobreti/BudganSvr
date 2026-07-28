namespace BudganServices.UseCases.ColumnsMapping.Get;

public interface IGetColumnsMappingUseCase : IBaseUseCase
{
    bool Succeeded { get; }
    BOGetColumnsMapping GetColumnsMappingResult { get; }
}