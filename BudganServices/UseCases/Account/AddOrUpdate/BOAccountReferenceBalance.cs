namespace BudganServices.UseCases.Account.AddOrUpdate;

public class BOAccountReferenceBalance
{
    public required DateOnly Date { get; set; }
    public required decimal Balance { get; set; }
}
