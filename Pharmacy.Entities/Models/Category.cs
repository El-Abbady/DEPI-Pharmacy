using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models;

public partial class Category
{
    
    public int CategoryId { get; set; }

    
    public string? CategoryName { get; set; }

    
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
