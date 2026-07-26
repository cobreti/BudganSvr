using BudganGlobal.Errors;
using BudganGlobal.Errors.Exceptions;
using BudganInfra.DBContext;
using Microsoft.EntityFrameworkCore;

namespace BudganInfra.Repositories.ColumnsMapping.Save;

internal class SaveColumnsMappingRepoOp : BaseRepositoryOperation, ISaveColumnsMappingRepoOp
{
    private readonly DataContext _dataContext;
    private readonly DaoSaveColumnsMapping _daoSaveColumnsMapping;
    private Guid _saveResultValue = Guid.Empty;
    private bool _succeeded = true;
    private ErrorValue? _errorValue = null;

    public DaoSaveColumnsMapping DaoSaveColumnsMapping => this._daoSaveColumnsMapping;
    
    public Guid SaveResultValue => this._saveResultValue;
    public bool Succeeded => this._succeeded;

    public ErrorValue ErrorValue
    {
        get
        {
            if (this._succeeded || this._errorValue == null)
            {
                throw new InvalidOperationException();
            }

            return this._errorValue;
        }
    }

    public SaveColumnsMappingRepoOp(DataContext dataContext, DaoSaveColumnsMapping daoSaveColumnsMapping)
    {
        this._dataContext = dataContext;
        this._daoSaveColumnsMapping = daoSaveColumnsMapping;
    }

    public async Task Execute()
    {
        if (this._daoSaveColumnsMapping.Id == null)
        {
            await this.Add();
        }
        else
        {
            await this.Update();
        }
    }

    private async Task Add()
    {
        try
        {
            var id = Guid.CreateVersion7();
            var columnsMapping = new DBContext.Tables.ColumnsMapping()
            {
                Id = id,
                Name = this._daoSaveColumnsMapping.Name,
                CardNumberColumnIndex = this._daoSaveColumnsMapping.CardNumberColumnIndex,
                CardNumberColumnText = this._daoSaveColumnsMapping.CardNumberColumnText,
                AmountColumnIndex = this._daoSaveColumnsMapping.AmountColumnIndex,
                AmountColumnText = this._daoSaveColumnsMapping.AmountColumnText,
                DateInscriptionColumnIndex = this._daoSaveColumnsMapping.DateInscriptionColumnIndex,
                DateInscriptionColumnText = this._daoSaveColumnsMapping.DateInscriptionColumnText,
                DescriptionColumnIndex = this._daoSaveColumnsMapping.DescriptionColumnIndex,
                DescriptionColumnText = this._daoSaveColumnsMapping.DescriptionColumnText,
            };

            await this._dataContext.ColumnsMappings.AddAsync(columnsMapping);
            await this._dataContext.SaveChangesAsync();

            this._saveResultValue = columnsMapping.Id;
        }
        catch (Exception ex)
        {
            this._succeeded = false;
        }
    }

    private async Task Update()
    {
        ArgumentNullException.ThrowIfNull(this._daoSaveColumnsMapping.Id);

        var id = Guid.Parse(this._daoSaveColumnsMapping.Id);
        var columnsMapping = await this._dataContext.ColumnsMappings
            .FirstOrDefaultAsync(x => x.Id == id);

        ValidateCanPerformUpdate(columnsMapping, this._daoSaveColumnsMapping);

        columnsMapping.Name = this._daoSaveColumnsMapping.Name;
        columnsMapping.CardNumberColumnIndex = this._daoSaveColumnsMapping.CardNumberColumnIndex;
        columnsMapping.CardNumberColumnText = this._daoSaveColumnsMapping.CardNumberColumnText;
        columnsMapping.AmountColumnIndex = this._daoSaveColumnsMapping.AmountColumnIndex;
        columnsMapping.AmountColumnText = this._daoSaveColumnsMapping.AmountColumnText;
        columnsMapping.DateInscriptionColumnIndex = this._daoSaveColumnsMapping.DateInscriptionColumnIndex;
        columnsMapping.DateInscriptionColumnText = this._daoSaveColumnsMapping.DateInscriptionColumnText;
        columnsMapping.DescriptionColumnIndex = this._daoSaveColumnsMapping.DescriptionColumnIndex;
        columnsMapping.DescriptionColumnText = this._daoSaveColumnsMapping.DescriptionColumnText;

        this._dataContext.ColumnsMappings.Update(columnsMapping);
        await this._dataContext.SaveChangesAsync();

        this._saveResultValue = id;
    }
}
