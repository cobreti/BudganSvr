namespace BudganInfra.Repositories.ColumnsMapping.GetList;

public interface IListColumnsMappingRepoOp : IRepositoryOperation
{
    List<DaoListColumnsMapping> GetListResult { get; }
}

