using BudganGlobal.Errors;
using BudganGlobal.Errors.Exceptions;
using BudganServices.UseCases.Account;
using BudganServices.UseCases.Account.AddOrUpdate;
using BudganSvr.Api.Controllers.Account.Models;
using BudganSvr.Api.Types;
using Microsoft.AspNetCore.Mvc;

namespace BudganSvr.Api.Controllers.Account;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountUseCaseFactory _accountUseCaseFactory;

    public AccountController(IAccountUseCaseFactory accountUseCaseFactory)
    {
        this._accountUseCaseFactory = accountUseCaseFactory;
    }

    [HttpPost]
    [Route("AddOrUpdate")]
    public async Task<IActionResult> AddOrUpdate(AddOrUpdateAccount model)
    {
        try
        {
            var boModel = new BOAddOrUpdateAccount
            {
                Id = model.Id,
                Timestamp = model.Timestamp,
                Name = model.Name,
                ColumnsMappingId = model.ColumnsMappingId,
                AccountType = model.AccountType,
            };
            var addOrUpdateUseCase = this._accountUseCaseFactory.AddOrUpdateUseCase(boModel);

            await addOrUpdateUseCase.ExecuteAsync();

            var result = new ApiSuccessResult<Guid>(addOrUpdateUseCase.ResultValue);

            return Ok(result);
        }
        catch (BudganException ex)
        {
            if (ex.BudganError == BudganErrorValue.ResourceNotFound)
            {
                return this.NotFound();
            }

            throw;
        }
    }
}
