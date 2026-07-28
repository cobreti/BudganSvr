using BudganInfra.Repositories.ColumnsMapping;

namespace BudganServices.UseCases.ColumnsMapping.Get;

public class GetColumnsMappingUseCase : IGetColumnsMappingUseCase
{
    private readonly IColumnsMappingRepository _repository;
    private readonly Guid _id;
    private BOGetColumnsMapping? _result = null;
    private bool _succeeded = true;

    public bool Succeeded => this._succeeded;
    
    public BOGetColumnsMapping GetColumnsMappingResult
    {
        get
        {
            ArgumentNullException.ThrowIfNull(this._result);
            return this._result;
        }
        
    }
    
    public GetColumnsMappingUseCase(IColumnsMappingRepository repository, Guid id)
    {
        this._repository = repository;
        this._id = id;
    }

    public async Task ExecuteAsync()
    {
        var repOp = this._repository.GetColumnsMappingRepoOperation(this._id);

        await repOp.ExecuteAsync();

        if (repOp.Succeeded)
        {
            var r = repOp.ResultValue;

            this._result = new BOGetColumnsMapping
            {
                Id = r.Id,
                Name = r.Name,
                CardNumberColumnIndex = r.CardNumberColumnIndex,
                CardNumberColumnText = r.CardNumberColumnText,
                DateInscriptionColumnIndex = r.DateInscriptionColumnIndex,
                DateInscriptionColumnText = r.DateInscriptionColumnText,
                AmountColumnIndex = r.AmountColumnIndex,
                AmountColumnText = r.AmountColumnText,
                DescriptionColumnIndex = r.DescriptionColumnIndex,
                DescriptionColumnText = r.DescriptionColumnText,
            };
        }
        else
        {
            this._succeeded = false;
        }
    }
}