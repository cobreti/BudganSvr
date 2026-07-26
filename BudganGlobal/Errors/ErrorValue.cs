namespace BudganGlobal.Errors;

public class ErrorValue
{
    public static ErrorValue ResourceNotFound = new ErrorValue("ResourceNotFound", "Resource not found");
    
    public string ErrorCode { get; }
    public string ErrorMessage { get; }
    
    protected ErrorValue(string errorCode, string errorMessage)
    {
        this.ErrorCode = errorCode;
        this.ErrorMessage = errorMessage;
    }
}