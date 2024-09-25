using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models;

public partial class Order
{
   
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    
    public DateTime? OrderDate { get; set; }

    public int? ShippingId { get; set; }

    
    public string? OrderStatus { get; set; }

    public int? PaymentId { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [ForeignKey("PaymentId")]
    [InverseProperty("Orders")]
    public virtual Payment? Payment { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [ForeignKey("ShippingId")]
    [InverseProperty("Orders")]
    public virtual Shipping? Shipping { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Orders")]
    public virtual User? User { get; set; }
}
