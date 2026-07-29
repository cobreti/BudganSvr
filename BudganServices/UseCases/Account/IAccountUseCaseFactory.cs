using BudganServices.UseCases.Account.AddOrUpdate;

namespace BudganServices.UseCases.Account;

public interface IAccountUseCaseFactory
{
    IAddOrUpdateAccountUseCase AddOrUpdateUseCase(BOAddOrUpdateAccount model);
}
