using System.ComponentModel.DataAnnotations;

namespace BudganInfra.DBContext.Tables;

public class ColumnsMapping
{
    [Key]
    public required Guid Id { get; set; }
    
    [MaxLength(100)]
    public required string Name { get; set; }

    public required int CardNumberColumnIndex { get; set; }
    
    [MaxLength(100)]
    public required string CardNumberColumnName { get; set; }

    public required int InscriptionColumnIndex { get; set; }
    
    [MaxLength(100)]
    public required string InscriptionColumnName { get; set; }

    public required int AmountColumnIndex { get; set; }
    
    [MaxLength(100)]
    public required string AmountColumnName { get; set; }

    public required int DescriptionColumnIndex { get; set; }
    
    [MaxLength(100)]
    public required string DescriptionColumnName { get; set; }
}
