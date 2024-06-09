using System.ComponentModel.DataAnnotations;

namespace Cw10.Models;

public class Role
{
    
    [Key]
    public int IdRole { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Name { get; set; }
    
    
}