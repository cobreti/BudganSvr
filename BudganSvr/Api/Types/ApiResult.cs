namespace BudganSvr.Api.Types;

public class ApiResult
{
    public bool Succeeded { get; set; }
}

public class ApiSuccessResult<TYPE> : ApiResult
{
    public ApiSuccessResult(TYPE successValue)
    {
        this.SuccessValue = successValue;
        this.Succeeded = true;
    }
    
    public TYPE SuccessValue { get; set; }
}

public class ApiErrorResult<ERROR_TYPE> : ApiResult
{
    public ApiErrorResult(ERROR_TYPE errorValue)
    {
        this.ErrorValue = errorValue;
        this.Succeeded = false;
    }

    public ERROR_TYPE ErrorValue { get; set; }
}
