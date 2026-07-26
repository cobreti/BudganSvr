using System.Runtime.Serialization;

namespace BudganGlobal.Errors.Exceptions;

[Serializable]
public class BudganException : Exception
{
    public string ErrorCode { get; }
    
    public BudganException(ErrorValue error) : base(error.ErrorMessage)
    {
        this.ErrorCode = error.ErrorCode;
    }
    
    protected BudganException(string message, ErrorValue error, Exception innerException) : base(message, innerException)
    {
        this.ErrorCode = error.ErrorCode;
    }

    protected BudganException(string message, ErrorValue error) : base(message)
    {
        this.ErrorCode = error.ErrorCode;
    }
}
