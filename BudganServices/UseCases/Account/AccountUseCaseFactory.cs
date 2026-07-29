using BudganInfra.Repositories.Account;
using BudganServices.UseCases.Account.AddOrUpdate;

namespace BudganServices.UseCases.Account;

internal class AccountUseCaseFactory : IAccountUseCaseFactory
{
    private readonly IAccountRepository _accountRepository;

    public AccountUseCaseFactory(IAccountRepository accountRepository)
    {
        this._accountRepository = accountRepository;
    }

    public IAddOrUpdateAccountUseCase AddOrUpdateUseCase(BOAddOrUpdateAccount model)
    {
        return new AddOrUpdateAccountUseCase(this._accountRepository, model);
    }
}
