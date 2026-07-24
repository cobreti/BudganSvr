using BudganInfra.DBContext;

namespace BudganInfra.Repositories.ColumnsMapping.Save;

internal class SaveColumnsMappingRepoOp : ISaveColumnsMappingRepoOp
{
    private readonly DataContext _dataContext;
    private readonly DaoSaveColumnsMapping _daoSaveColumnsMapping;

    public DaoSaveColumnsMapping DaoSaveColumnsMapping => this._daoSaveColumnsMapping;

    public SaveColumnsMappingRepoOp(DataContext dataContext, DaoSaveColumnsMapping daoSaveColumnsMapping)
    {
        this._dataContext = dataContext;
        this._daoSaveColumnsMapping = daoSaveColumnsMapping;
    }

    public async Task Execute()
    {
        var Id = this._daoSaveColumnsMapping.Id != null ? Guid.Parse(this._daoSaveColumnsMapping.Id) : Guid.NewGuid();
        
        DBContext.Tables.ColumnsMapping columnsMapping = new()
        {
            Id = Id,
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
        
    }
}
