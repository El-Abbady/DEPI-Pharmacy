using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("Product")]
public partial class Product
{
    [Key]
    [Column("Product_ID")]
    public int ProductId { get; set; }

    [Column("Product_Name")]
    [StringLength(100)]
    
    public string ProductName { get; set; } = null!;

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [Column("Quantity_InStock")]
    public int QuantityInStock { get; set; }

    [Column("Category_ID")]
    public int? CategoryId { get; set; }

    [Column("Image_URL")]
    [StringLength(255)]
    
    public string? ImageUrl { get; set; }

    [Column("Expiry_Date")]
    public DateOnly? ExpiryDate { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category? Category { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [InverseProperty("Product")]
    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
}
