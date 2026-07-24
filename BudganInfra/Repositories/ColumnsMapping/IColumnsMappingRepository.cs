using BudganInfra.Repositories.ColumnsMapping.Save;

namespace BudganInfra.Repositories.ColumnsMapping;

public interface IColumnsMappingRepository
{
    ISaveColumnsMappingRepoOp GetSaveColumnsMappingRepoOperation(DaoSaveColumnsMapping daoSaveColumnsMapping);
}