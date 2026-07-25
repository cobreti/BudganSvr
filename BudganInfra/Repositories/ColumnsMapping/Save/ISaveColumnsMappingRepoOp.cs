namespace BudganInfra.Repositories.ColumnsMapping.Save;

public interface ISaveColumnsMappingRepoOp : IRepositoryOperation
{
    Guid SaveResultValue { get; }
}