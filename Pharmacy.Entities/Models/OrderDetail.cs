
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class OrderDetail
{
    [Key]
    [Column("Order_Detail_ID")]
    public int OrderDetailId { get; set; }

    [Column("Order_ID")]
    public int? OrderId { get; set; }

    [Column("Product_ID")]
    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    [Column("Unit_Price", TypeName = "decimal(10, 2)")]
    public decimal UnitPrice { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderDetails")]
    public virtual Order? Order { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("OrderDetails")]
    public virtual Product? Product { get; set; }
}
