using BudganInfra.DBContext;
using Microsoft.EntityFrameworkCore;

namespace BudganInfra.Repositories.ColumnsMapping.GetList;

internal class ListColumnsMappingRepoOp : BaseRepositoryOperation, IListColumnsMappingRepoOp
{
    private readonly DataContext _dataContext;
    private List<DaoListColumnsMapping> _daoGetListColumnsMappings = [];
    private bool _succeeded = true;

    public List<DaoListColumnsMapping> GetListResult => _daoGetListColumnsMappings;
    public bool Succeeded => _succeeded;

    public ListColumnsMappingRepoOp(DataContext dataContext)
    {
        this._dataContext = dataContext;
    }

    public async Task Execute()
    {
        this._daoGetListColumnsMappings = await this._dataContext.ColumnsMappings
            .Select(x => new DaoListColumnsMapping
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
                DescriptionColumnText = x.DescriptionColumnText
            })
            .ToListAsync();
    }
}