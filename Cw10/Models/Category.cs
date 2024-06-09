using System.ComponentModel.DataAnnotations;

namespace Cw10.Models;

public class Category
{
    [Key]
    public int IdCategory { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Name { get; set; }

}