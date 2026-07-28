using System.Diagnostics.CodeAnalysis;
using BudganGlobal.Errors;
using BudganGlobal.Errors.Exceptions;
using BudganInfra.DBContext.Tables;
using BudganInfra.Repositories.Models;

namespace BudganInfra.Repositories;

public abstract class BaseRepositoryOperation
{
    private ErrorValue? _errorValue = null;

    public bool Succeeded { get; protected set; } = true;

    public ErrorValue ErrorValue
    {
        get
        {
            if (this.Succeeded || this._errorValue == null)
            {
                throw new InvalidOperationException();
            }

            return this._errorValue;
        }

        protected set => this._errorValue = value;
    }

    protected void ValidateCanPerformUpdate([NotNull] BaseEntity? entity, DaoBaseUpdateModel updateModel)
    {
        if (entity == null)
        {
            throw new BudganException(ErrorValue.ResourceNotFound);
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

    protected void SetSucceeded()
    {
        this.Succeeded = true;
    }

    protected void SetFailed()
    {
        this.Succeeded = false;
    }

    protected void SetFailed(ErrorValue errorValue)
    {
        this.ErrorValue = errorValue;
        this.Succeeded = false;
    }
}
