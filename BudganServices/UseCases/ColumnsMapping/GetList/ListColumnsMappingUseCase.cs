using BudganInfra.Repositories.ColumnsMapping;

namespace BudganServices.UseCases.ColumnsMapping.GetList;

internal class ListColumnsMappingUseCase : IListColumnsMappingUseCase
{
    private IColumnsMappingRepository _repository;
    private List<BOListColumnsMapping> _columnsMappings = [];

    public List<BOListColumnsMapping> GetListResult => this._columnsMappings;
    
    public ListColumnsMappingUseCase(IColumnsMappingRepository repository)
    {
        this._repository = repository;
    }
    
    public async Task ExecuteAsync()
    {
        var repoOp = this._repository
            .ListColumnsMappingRepoOperation();
        
        await repoOp.ExecuteAsync();

        this._columnsMappings = repoOp.ResultValue
            .Select(x => new BOListColumnsMapping
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