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



    [ForeignKey("UserId")]
    public virtual User? User { get; set; }
}
