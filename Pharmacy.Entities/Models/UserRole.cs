using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public partial class UserRole
{
    [Key]
    [Column("Role_ID")]
    public int RoleId { get; set; }

    [Column("Role_Name")]
    [StringLength(50)]
    
    public string RoleName { get; set; } = null!;
}
