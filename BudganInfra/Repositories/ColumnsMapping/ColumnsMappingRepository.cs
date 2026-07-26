using BudganInfra.DBContext;
using BudganInfra.Repositories.ColumnsMapping.Save;
using Microsoft.Extensions.Logging;

namespace BudganInfra.Repositories.ColumnsMapping;

internal class ColumnsMappingRepository : IColumnsMappingRepository
{
    private readonly DataContext dataContext;
    private readonly ILogger<ColumnsMappingRepository> logger;

    public ColumnsMappingRepository(DataContext dataContext, ILogger<ColumnsMappingRepository> logger)
    {
        this.dataContext = dataContext;
        this.logger = logger;
    }
    
    public ISaveColumnsMappingRepoOp GetSaveColumnsMappingRepoOperation(DaoSaveColumnsMapping daoSaveColumnsMapping)
    {
        return new SaveColumnsMappingRepoOp(this.dataContext, daoSaveColumnsMapping);
    }
}
