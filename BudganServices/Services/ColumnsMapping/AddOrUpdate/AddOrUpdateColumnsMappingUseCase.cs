using BudganInfra.Repositories.ColumnsMapping;
using BudganInfra.Repositories.ColumnsMapping.Save;

namespace BudganServices.Services.ColumnsMapping.AddOrUpdate;

internal class AddOrUpdateColumnsMappingUseCase : IAddOrUpdateColumnsMappingUseCase
{
    private readonly IColumnsMappingRepository _columnsMappingRepository;
    private readonly BOAddOrUpdateColumnsMapping _boAddOrUpdateModel;
    private Guid _result = Guid.Empty;
    
    public Guid Result => this._result;

    public AddOrUpdateColumnsMappingUseCase(IColumnsMappingRepository columnsMappingRepository, BOAddOrUpdateColumnsMapping model)
    {
        this._columnsMappingRepository = columnsMappingRepository;
        this._boAddOrUpdateModel = model;
    }

    public async Task Execute()
    {
        var daoSave = new DaoSaveColumnsMapping
        {
            Id = this._boAddOrUpdateModel.Id,
            Name = this._boAddOrUpdateModel.Name,
            CardNumberColumnIndex = this._boAddOrUpdateModel.CardNumberColumnIndex,
            CardNumberColumnText = this._boAddOrUpdateModel.CardNumberColumnText,
            DateInscriptionColumnIndex = this._boAddOrUpdateModel.DateInscriptionColumnIndex,
            DateInscriptionColumnText = this._boAddOrUpdateModel.DateInscriptionColumnText,
            AmountColumnIndex = this._boAddOrUpdateModel.AmountColumnIndex,
            AmountColumnText = this._boAddOrUpdateModel.AmountColumnText,
            DescriptionColumnIndex = this._boAddOrUpdateModel.DescriptionColumnIndex,
            DescriptionColumnText = this._boAddOrUpdateModel.DescriptionColumnText,
        };

        var repoOp = this._columnsMappingRepository.SaveColumnsMappingRepoOperation(daoSave);

        await repoOp.Execute();
        
        this._result = repoOp.SaveResultValue;
    }
}
