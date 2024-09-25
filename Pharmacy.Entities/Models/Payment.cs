using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    

namespace Models;

public partial class Payment
{
    [Key]
    public int PaymentId { get; set; }

    public int? OrderId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PaymentDate { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? PaymentAmount { get; set; }

    [StringLength(50)]
    
    public string? PaymentMethod { get; set; }

    [StringLength(50)]
    
    public string? PaymentStatus { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("Payments")]
    public virtual Order? Order { get; set; }

    [InverseProperty("Payment")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
