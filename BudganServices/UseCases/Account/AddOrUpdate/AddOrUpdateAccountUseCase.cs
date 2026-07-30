using BudganInfra.Repositories.Account;
using BudganInfra.Repositories.Account.Save;

namespace BudganServices.UseCases.Account.AddOrUpdate;

internal class AddOrUpdateAccountUseCase : BaseUseCaseWithResultValue<Guid>, IAddOrUpdateAccountUseCase
{
    private readonly IAccountRepository _accountRepository;
    private readonly BOAddOrUpdateAccount _boAddOrUpdateModel;

    public AddOrUpdateAccountUseCase(IAccountRepository accountRepository, BOAddOrUpdateAccount model)
    {
        this._accountRepository = accountRepository;
        this._boAddOrUpdateModel = model;
    }

    public async Task ExecuteAsync()
    {
        var daoSave = new DaoSaveAccount
        {
            Id = this._boAddOrUpdateModel.Id,
            Timestamp = this._boAddOrUpdateModel.Timestamp,
            Name = this._boAddOrUpdateModel.Name,
            ColumnsMappingId = this._boAddOrUpdateModel.ColumnsMappingId,
            AccountType = this._boAddOrUpdateModel.AccountType,
            ReferenceBalance = this._boAddOrUpdateModel.ReferenceBalance == null
                ? null
                : new DaoAccountReferenceBalance
                {
                    Date = this._boAddOrUpdateModel.ReferenceBalance.Date,
                    Balance = this._boAddOrUpdateModel.ReferenceBalance.Balance,
                },
        };

        var repoOp = this._accountRepository.SaveAccountRepoOperation(daoSave);

        await repoOp.ExecuteAsync();

        this.SetSucceeded(repoOp.ResultValue);
    }
}
