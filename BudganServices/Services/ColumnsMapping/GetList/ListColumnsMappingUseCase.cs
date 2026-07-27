using BudganInfra.Repositories.ColumnsMapping;

namespace BudganServices.Services.ColumnsMapping.GetList;

internal class ListColumnsMappingUseCase : IListColumnsMappingUseCase
{
    private IColumnsMappingRepository _repository;
    private List<ListColumnsMapping> _columnsMappings = [];

    public List<ListColumnsMapping> GetListResult => _columnsMappings;
    
    public ListColumnsMappingUseCase(IColumnsMappingRepository repository)
    {
        this._repository = repository;
    }
    
    public async Task Execute()
    {
        var repoOp = this._repository
            .ListColumnsMappingRepoOperation();
        
        await repoOp.ExecuteAsync();

        this._columnsMappings = repoOp.GetListResult
            .Select(x => new ListColumnsMapping
            {
                Id = x.Id.ToString(),
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