using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class User
{
    [Key]
    [Column("User_ID")]
    public int UserId { get; set; }

    [Column("First_Name")]
    [StringLength(100)]
    
    public string FirstName { get; set; } = null!;

    [Column("Last_Name")]
    [StringLength(100)]
    
    public string LastName { get; set; } = null!;

    [StringLength(150)]
    
    public string Email { get; set; } = null!;

    [StringLength(255)]
    
    public string Password { get; set; } = null!;

    [StringLength(255)]
    
    public string? Address { get; set; }

    [Column("Phone_Number")]
    [StringLength(20)]
   
    public string? PhoneNumber { get; set; }

    [Column("Role_ID")]
    public int? RoleId { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [InverseProperty("User")]
    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
}
