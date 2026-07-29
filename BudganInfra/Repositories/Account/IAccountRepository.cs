using BudganInfra.Repositories.Account.GetList;
using BudganInfra.Repositories.Account.Save;

namespace BudganInfra.Repositories.Account;

public interface IAccountRepository
{
    ISaveAccountRepoOp SaveAccountRepoOperation(DaoSaveAccount daoSaveAccount);
    IListAccountRepoOp ListAccountRepoOperation();
}
