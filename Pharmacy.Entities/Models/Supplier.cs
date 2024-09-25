using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models;

public partial class Supplier
{
    [Key]
    public int SupplierId { get; set; }

    public int? UserId { get; set; }

    public int? RoleId { get; set; }

    [InverseProperty("Supplier")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    [ForeignKey("RoleId")]
    [InverseProperty("Suppliers")]
    public virtual Role? Role { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Suppliers")]
    public virtual User? User { get; set; }
}
