namespace BudganSvr.Api.Controllers.Account.Models;

public class AccountReferenceBalance
{
    public required DateOnly Date { get; set; }
    public required decimal Balance { get; set; }
}
