using System.ComponentModel.DataAnnotations.Schema;

namespace BudganInfra.DBContext.Tables;

[Table("AccountReferenceBalance")]
public class AccountReferenceBalance : BaseEntity
{
    public DateTime Date { get; set; }
    public decimal Balance { get; set; }
    
    public required Guid AccountId { get; set; }
    public Account Account { get; set; }
}
