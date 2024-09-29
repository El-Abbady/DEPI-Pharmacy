using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models;

public partial class User
{
    [Key]
    public int UserId { get; set; }

    [StringLength(100)]
   
    public string? FirstName { get; set; }

    [StringLength(100)]
    
    public string? LastName { get; set; }

    [StringLength(15)]
    
    public string? Phone { get; set; }

    [StringLength(100)]
   
    public string Email { get; set; }

    [StringLength(255)]
    
    public string? Address { get; set; }

    [StringLength(255)]
    
    public string? PasswordHash { get; set; }

    public int? RoleId { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("User")]
    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role? Role { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();

    [InverseProperty("User")]
    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
