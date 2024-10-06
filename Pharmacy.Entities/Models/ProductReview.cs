using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models;

public partial class ProductReview
{
    [Key]
    public int ReviewId { get; set; }

    public int? ProductId { get; set; }

    public int? UserId { get; set; }

    
    
    public string? UserName { get; set; }

    [Column(TypeName = "text")]
    public string? ContentReview { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductReviews")]
    public virtual Product? Product { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("ProductReviews")]
    public virtual User? User { get; set; }
}
