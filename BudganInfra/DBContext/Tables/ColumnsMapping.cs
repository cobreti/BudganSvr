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
    public required string? CardNumberColumnText { get; set; }

    public required int DateInscriptionColumnIndex { get; set; }
    
    [MaxLength(100)]
    public required string? DateInscriptionColumnText { get; set; }

    public required int AmountColumnIndex { get; set; }
    
    [MaxLength(100)]
    public required string? AmountColumnText { get; set; }

    public required int DescriptionColumnIndex { get; set; }
    
    [MaxLength(100)]
    public required string? DescriptionColumnText { get; set; }

    public DateTime Timestamp { get; set; }
}
