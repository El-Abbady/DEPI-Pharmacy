using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models;

[Table("ShoppingCart")]
public partial class ShoppingCart
{
    [Key]
    public int CartId { get; set; }

    public int? UserId { get; set; }

    [InverseProperty("Cart")]
    public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

    [ForeignKey("UserId")]
    [InverseProperty("ShoppingCarts")]
    public virtual User? User { get; set; }
}
