using BudganInfra.DBContext;
using BudganInfra.Repositories.Account.GetList;
using BudganInfra.Repositories.Account.Save;
using Microsoft.Extensions.Logging;

namespace BudganInfra.Repositories.Account;

internal class AccountRepository : IAccountRepository
{
    private readonly DataContext _dataContext;
    private readonly ILogger<AccountRepository> _logger;

    public AccountRepository(ILogger<AccountRepository> logger, DataContext dataContext)
    {
        this._logger = logger;
        this._dataContext = dataContext;
    }

    public ISaveAccountRepoOp SaveAccountRepoOperation(DaoSaveAccount daoSaveAccount)
    {
        return new SaveAccountRepoOp(this._dataContext, daoSaveAccount);
    }

    public IListAccountRepoOp ListAccountRepoOperation()
    {
        return new ListAccountRepoOp(this._dataContext);
    }
}
