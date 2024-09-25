using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dto;

public class ProductDto
{
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

   
}
