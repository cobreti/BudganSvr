using BudganInfra.DBContext;
using BudganInfra.Repositories.ColumnsMapping.Models;

namespace BudganInfra.Repositories.ColumnsMapping;

internal class ColumnsMappingRepository : IColumnsMappingRepository
{
    private readonly DataContext dataContext;

    public ColumnsMappingRepository(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }
    
    public async Task Save(DaoSaveColumnsMapping daoSaveColumnsMapping)
    {
        var Id = daoSaveColumnsMapping.Id != null ? Guid.Parse(daoSaveColumnsMapping.Id) : Guid.NewGuid();
        
        DBContext.Tables.ColumnsMapping columnsMapping = new()
        {
            Id = Id,
            Name = daoSaveColumnsMapping.Name,
            
            CardNumberColumnIndex = daoSaveColumnsMapping.CardNumberColumnIndex,
            CardNumberColumnText = daoSaveColumnsMapping.CardNumberColumnText,
            
            AmountColumnIndex = daoSaveColumnsMapping.AmountColumnIndex,
            AmountColumnText = daoSaveColumnsMapping.AmountColumnText,
            
            DateInscriptionColumnIndex = daoSaveColumnsMapping.DateInscriptionColumnIndex,
            DateInscriptionColumnText = daoSaveColumnsMapping.DateInscriptionColumnText,
            
            DescriptionColumnIndex = daoSaveColumnsMapping.DescriptionColumnIndex,
            DescriptionColumnText = daoSaveColumnsMapping.DescriptionColumnText,
        };
        
        await dataContext.ColumnsMappings.AddAsync(columnsMapping);
        await dataContext.SaveChangesAsync();
    }
}
