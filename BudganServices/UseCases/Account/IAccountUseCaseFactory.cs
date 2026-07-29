using BudganServices.UseCases.Account.AddOrUpdate;
using BudganServices.UseCases.Account.GetList;

namespace BudganServices.UseCases.Account;

public interface IAccountUseCaseFactory
{
    IAddOrUpdateAccountUseCase AddOrUpdateUseCase(BOAddOrUpdateAccount model);
    IListAccountUseCase ListAccountUseCase();
}
