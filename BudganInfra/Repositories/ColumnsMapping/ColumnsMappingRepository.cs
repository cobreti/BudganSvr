using BudganInfra.DBContext;
using BudganInfra.Repositories.ColumnsMapping.Save;

namespace BudganInfra.Repositories.ColumnsMapping;

internal class ColumnsMappingRepository : IColumnsMappingRepository
{
    private readonly DataContext dataContext;

    public ColumnsMappingRepository(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }
    
    public ISaveColumnsMappingRepoOp GetSaveColumnsMappingRepoOperation(DaoSaveColumnsMapping daoSaveColumnsMapping)
    {
        return new SaveColumnsMappingRepoOp(this.dataContext, daoSaveColumnsMapping);
    }
}
