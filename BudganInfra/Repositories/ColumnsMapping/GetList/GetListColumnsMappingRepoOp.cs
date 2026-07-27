using BudganInfra.DBContext;
using Microsoft.EntityFrameworkCore;

namespace BudganInfra.Repositories.ColumnsMapping.GetList;

internal class GetListColumnsMappingRepoOp : BaseRepositoryOperation, IGetListColumnsMappingRepoOp
{
    private readonly DataContext _dataContext;
    private List<DaoGetListColumnsMapping> _daoGetListColumnsMappings = [];
    private bool _succeeded = true;

    public List<DaoGetListColumnsMapping> GetListResult => _daoGetListColumnsMappings;
    public bool Succeeded => _succeeded;

    public GetListColumnsMappingRepoOp(DataContext dataContext)
    {
        this._dataContext = dataContext;
    }

    public async Task Execute()
    {
        this._daoGetListColumnsMappings = await this._dataContext.ColumnsMappings
            .Select(x => new DaoGetListColumnsMapping
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