using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("ShoppingCart")]
public partial class ShoppingCart
{
    [Key]
    [Column("Cart_ID")]
    public int CartId { get; set; }

    [Column("User_ID")]
    public int? UserId { get; set; }

    [Column("Product_ID")]
    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ShoppingCarts")]
    public virtual Product? Product { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("ShoppingCarts")]
    public virtual User? User { get; set; }
}
