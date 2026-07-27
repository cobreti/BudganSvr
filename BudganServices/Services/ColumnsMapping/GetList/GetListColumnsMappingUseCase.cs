using BudganInfra.Repositories.ColumnsMapping;

namespace BudganServices.Services.ColumnsMapping.GetList;

internal class GetListColumnsMappingUseCase : IGetListColumnsMappingUseCase
{
    private IColumnsMappingRepository _repository;
    private List<BOGetListColumnsMapping> _columnsMappings = [];

    public List<BOGetListColumnsMapping> GetListResult => _columnsMappings;
    
    public GetListColumnsMappingUseCase(IColumnsMappingRepository repository)
    {
        this._repository = repository;
    }
    
    public async Task Execute()
    {
        var repoOp = this._repository
            .GetListColumnsMappingRepoOperation();
        
        await repoOp.Execute();

        this._columnsMappings = repoOp.GetListResult
            .Select(x => new BOGetListColumnsMapping
            {
                Id = x.Id,
                Name = x.Name,
                CardNumberColumnIndex = x.CardNumberColumnIndex,
                CardNumberColumnText = x.CardNumberColumnText,
                DateInscriptionColumnIndex = x.DateInscriptionColumnIndex,
                DateInscriptionColumnText = x.DateInscriptionColumnText,
                AmountColumnIndex = x.AmountColumnIndex,
                AmountColumnText = x.AmountColumnText,
                DescriptionColumnIndex = x.DescriptionColumnIndex,
                DescriptionColumnText = x.DescriptionColumnText,
            })
            .ToList();
    }
}