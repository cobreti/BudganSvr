using BudganInfra.Repositories.ColumnsMapping.Models;

namespace BudganInfra.Repositories.ColumnsMapping;

public interface IColumnsMappingRepository
{
    Task Save(DaoSaveColumnsMapping daoSaveColumnsMapping);
}