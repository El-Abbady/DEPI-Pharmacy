
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class Order
{
    [Key]
    [Column("Order_ID")]
    public int OrderId { get; set; }

    [Column("User_ID")]
    public int? UserId { get; set; }

    [Column("Order_Date", TypeName = "datetime")]
    public DateTime OrderDate { get; set; }

    [Column("Order_Status")]
    [StringLength(50)]
    
    public string OrderStatus { get; set; } = null!;

    [Column("Total_Amount", TypeName = "decimal(10, 2)")]
    public decimal TotalAmount { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [InverseProperty("Order")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [ForeignKey("UserId")]
    [InverseProperty("Orders")]
    public virtual User? User { get; set; }
}
