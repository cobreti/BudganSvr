namespace BudganInfra.DBContext;

public class EFColumnsMapping
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    
    public required int CardNumberColumnIndex { get; set; }
    public required string CardNumberColumnName { get; set; }
    
    public required int InscriptionColumnIndex { get; set; }
    public required string InscriptionColumnName { get; set; }
    
    public required int AmountColumnIndex { get; set; }
    public required string AmountColumnName { get; set; }
    
    public required int DescriptionColumnIndex { get; set; }
    public required string DescriptionColumnName { get; set; }
}
