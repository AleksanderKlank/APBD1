using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cw10.Models;

[Table("Roles")]
public class Role
{
    [Key]
    [Column("PK_role")]
    public int IdRole { get; set; }
    
    [MaxLength(100)]
    [Required]
    [Column("name")]
    public string Name { get; set; }
    
    
}