namespace BudganInfra.Repositories.ColumnsMapping.GetList;

public interface IGetListColumnsMappingRepoOp : IRepositoryOperation
{
    List<DaoGetListColumnsMapping> GetListResult { get; }
}

