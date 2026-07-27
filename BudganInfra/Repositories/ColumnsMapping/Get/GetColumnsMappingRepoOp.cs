using BudganInfra.DBContext;

namespace BudganInfra.Repositories.ColumnsMapping.Get;

public class GetColumnsMappingRepoOp : BaseRepositoryOperation, IGetColumnsMappingRepoOp
{
    private readonly DataContext _dataContext;
    private readonly Guid _id;
    private DaoGetColumnsMapping? _daoGetColumnsMapping = null;
    private bool _succeeded = true;

    public bool Succeeded => _succeeded;

    public DaoGetColumnsMapping GetColumnsMappingResult
    {
        get
        {
            ArgumentNullException.ThrowIfNull(this._daoGetColumnsMapping);
            
            return this._daoGetColumnsMapping;
        }
    }

    public GetColumnsMappingRepoOp(DataContext dataContext, Guid id)
    {
        this._dataContext = dataContext;
        this._id = id;
    }

    public async Task ExecuteAsync()
    {
        var entity = this._dataContext.ColumnsMappings
            .FirstOrDefault(x => x.Id == this._id);

        if (entity != null)
        {
            this._daoGetColumnsMapping = new DaoGetColumnsMapping
            {
                Id = entity.Id.ToString(),
                Name = entity.Name,
                CardNumberColumnIndex = entity.CardNumberColumnIndex,
                CardNumberColumnText = entity.CardNumberColumnText,
                DateInscriptionColumnIndex = entity.DateInscriptionColumnIndex,
                DateInscriptionColumnText = entity.DateInscriptionColumnText,
                AmountColumnIndex = entity.AmountColumnIndex,
                AmountColumnText = entity.AmountColumnText,
                DescriptionColumnIndex = entity.DescriptionColumnIndex,
                DescriptionColumnText = entity.DescriptionColumnText
            };
        }
        else
        {
            this._succeeded = false;
        }
    }
}