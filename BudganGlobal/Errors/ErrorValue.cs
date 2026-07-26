namespace BudganGlobal.Errors;

public class ErrorValue
{
    private static readonly Dictionary<string, ErrorValue> ByCode = new();

    public static ErrorValue ResourceNotFound = new ErrorValue("ResourceNotFound", "Resource not found");
    public static ErrorValue Exception = new ErrorValue("ExceptionOccurred", "An exception occured : information in logs");

    public string ErrorCode { get; }
    public string ErrorMessage { get; }

    protected ErrorValue(string errorCode, string errorMessage)
    {
        this.ErrorCode = errorCode;
        this.ErrorMessage = errorMessage;

        ByCode.Add(errorCode, this);
    }

    public static ErrorValue FromCode(string errorCode)
    {
        return ByCode[errorCode];
    }
}