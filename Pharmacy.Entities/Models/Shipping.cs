using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models;

[Table("Shipping")]
public partial class Shipping
{
    [Key]
    public int ShippingId { get; set; }

    [StringLength(255)]
    
    public string? Description { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? BaseCost { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? CostPerUnit { get; set; }

    public int? EstimatedDeliveryTime { get; set; }

    [InverseProperty("Shipping")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
