using System.Runtime.Serialization;

namespace BudganGlobal.Errors.Exceptions;

[Serializable]
public class BudganException : Exception
{
    public ErrorValue Error { get; }
    
    public BudganException(ErrorValue error) : base(error.ErrorMessage)
    {
        this.Error = error;
    }
    
    protected BudganException(string message, ErrorValue error, Exception innerException) : base(message, innerException)
    {
        this.Error = error;
    }

    protected BudganException(string message, ErrorValue error) : base(message)
    {
        this.Error = error;
    }
}
