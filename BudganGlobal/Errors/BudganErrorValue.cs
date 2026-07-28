namespace BudganGlobal.Errors;

public class BudganErrorValue
{
    private static readonly Dictionary<string, BudganErrorValue> ByCode = new();

    public static BudganErrorValue ResourceNotFound = new BudganErrorValue("ResourceNotFound", "Resource not found");
    public static BudganErrorValue Exception = new BudganErrorValue("ExceptionOccurred", "An exception occured : information in logs");

    public string ErrorCode { get; }
    public string ErrorMessage { get; }

    protected BudganErrorValue(string errorCode, string errorMessage)
    {
        this.ErrorCode = errorCode;
        this.ErrorMessage = errorMessage;

        ByCode.Add(errorCode, this);
    }

    public static BudganErrorValue FromCode(string errorCode)
    {
        return ByCode[errorCode];
    }
}