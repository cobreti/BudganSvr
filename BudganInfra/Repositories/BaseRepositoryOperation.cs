using System.Diagnostics.CodeAnalysis;
using BudganInfra.DBContext.Tables;
using BudganInfra.Repositories.Models;

namespace BudganInfra.Repositories;

public abstract class BaseRepositoryOperation
{
    protected void ValidateCanPerformUpdate([NotNull] BaseEntity? entity, DaoBaseUpdateModel updateModel)
    {
        if (entity == null)
        {
            throw new Exception("indicated resource not found");
        }

        if (updateModel.Timestamp == null)
        {
            throw new Exception("timestamp value required for update operation");
        }

        if (entity.Timestamp != updateModel.Timestamp)
        {
            throw new Exception("indicated resource has been modified");
        }
    }
}
