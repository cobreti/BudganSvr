namespace BudganInfra.Repositories.ColumnsMapping.Get;

public interface IGetColumnsMappingRepoOp : IRepositoryOperation
{
    DaoGetColumnsMapping GetColumnsMappingResult { get; }
}
