using BudganGlobal.Errors;
using BudganGlobal.Errors.Exceptions;
using BudganServices.Services.ColumnsMapping;
using BudganServices.Services.ColumnsMapping.AddOrUpdate;
using BudganSvr.Api.Controllers.ColumnsMapping.Models;
using BudganSvr.Api.Types;
using Microsoft.AspNetCore.Mvc;

namespace BudganSvr.Api.Controllers.ColumnsMapping;

[ApiController]
[Route("api/[controller]")]
public class ColumnsMappingController : ControllerBase
{
    private readonly IColumnsMappingService _columnsMappingService;

    public ColumnsMappingController(IColumnsMappingService columnsMappingService)
    {
        this._columnsMappingService = columnsMappingService;
    }
    
    [HttpPost]
    [Route("AddOrUpdate")]
    public async Task<IActionResult> AddOrUpdate(AddOrUpdateColumnsMapping model)
    {
        try
        {
            var boModel = new BOAddOrUpdateColumnsMapping
            {
                Id = model.Id,
                Name = model.Name,
                CardNumberColumnIndex = model.CardNumberColumnIndex,
                CardNumberColumnText = model.CardNumberColumnText,
                DateInscriptionColumnIndex = model.DateInscriptionColumnIndex,
                DateInscriptionColumnText = model.DateInscriptionColumnText,
                AmountColumnIndex = model.AmountColumnIndex,
                AmountColumnText = model.AmountColumnText,
                DescriptionColumnIndex = model.DescriptionColumnIndex,
                DescriptionColumnText = model.DescriptionColumnText,
            };
            var addOrUpdateUseCase = this._columnsMappingService.AddOrUpdateUseCase(boModel);

            await addOrUpdateUseCase.Execute();

            var result = new ApiSuccessResult<Guid>(addOrUpdateUseCase.Result);

            return Ok(result);
        }
        catch (BudganException ex)
        {
            if (ex.Error == ErrorValue.ResourceNotFound)
            {
                return this.NotFound();
            }

            throw;
        }
    }

    [HttpGet]
    [Route("List")]
    public async Task<IActionResult> ListColumnsMapping()
    {
        var listColumnsMappingUseCase = this._columnsMappingService.ListColumnsMappingUseCase();

        await listColumnsMappingUseCase.Execute();

        var model = listColumnsMappingUseCase.GetListResult
            .Select(x => new ListColumnsMapping
                {
                    Id = x.Id,
                    Name = x.Name,
                    CardNumberColumnIndex = x.CardNumberColumnIndex,
                    CardNumberColumnText = x.CardNumberColumnText,
                    DateInscriptionColumnIndex = x.DateInscriptionColumnIndex,
                    DateInscriptionColumnText = x.DateInscriptionColumnText,
                    AmountColumnIndex = x.AmountColumnIndex,
                    AmountColumnText = x.AmountColumnText,
                    DescriptionColumnIndex = x.DescriptionColumnIndex,
                    DescriptionColumnText = x.DescriptionColumnText,
                }
            )
            .ToList();

        return this.Ok(model);
    }
}
