using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("Payment")]
public partial class Payment
{
    [Key]
    [Column("Payment_ID")]
    public int PaymentId { get; set; }

    [Column("Order_ID")]
    public int? OrderId { get; set; }

    [Column("Payment_Date", TypeName = "datetime")]
    public DateTime PaymentDate { get; set; }

    [Column("Payment_Type")]
    [StringLength(50)]
   
    public string PaymentType { get; set; } = null!;

    [Column("Amount_Paid", TypeName = "decimal(10, 2)")]
    public decimal AmountPaid { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("Payments")]
    public virtual Order? Order { get; set; }
}
