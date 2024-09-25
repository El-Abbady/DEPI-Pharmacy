using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models;

public partial class ShoppingCartItem
{
    [Key]
    public int CartItemId { get; set; }

    public int? CartId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? UnitPrice { get; set; }

    [Column(TypeName = "decimal(21, 2)")]
    public decimal? LineTotal { get; set; }

    [ForeignKey("CartId")]
    [InverseProperty("ShoppingCartItems")]
    public virtual ShoppingCart? Cart { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ShoppingCartItems")]
    public virtual Product? Product { get; set; }
}
