
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

[Table("Category")]
public partial class Category
{
    [Key]
    [Column("Category_ID")]
    public int CategoryId { get; set; }

    [Column("Category_Name")]
    [StringLength(100)]
    
    public string CategoryName { get; set; } = null!;

    [InverseProperty("Category")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
