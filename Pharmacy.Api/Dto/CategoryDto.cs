using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Api.Dto;

public class CategoryDto
{
    public int CategoryId { get; set; }



    public string CategoryName { get; set; } = null!;

}
