using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models;

public partial class ShoppingCartItem
{
    [Key]
    public int CartItemId { get; set; }

    [ForeignKey("User")]
    public int? UserId { get; set; }
    
    public virtual User? User { get; set; }

    public int? Quantity { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? UnitPrice { get; set; }

    [Column(TypeName = "decimal(21, 2)")]
    public decimal? LineTotal { get; set; }

    

    [ForeignKey("Product")]
    public int? ProductId { get; set; }
   
    public virtual Product? Product { get; set; }
}
