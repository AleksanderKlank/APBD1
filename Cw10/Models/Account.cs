using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cw10.Models;

public class Account
{
    [Key]
    public int IdAccount { get; set; }
    
    [ForeignKey("Role")]
    public int IdRole { get; set; }
    
    
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [Required]
    [MaxLength(80)]
    public string Email { get; set; }
    
    [MaxLength(9)]
    public string? Phone { get; set; }
}