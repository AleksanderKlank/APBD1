using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Cw10.Models;

public class Product
{
    [Key]
    public int IdProduct { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    [Precision(5,2)]
    public double Weight { get; set; }
    
    [Required]
    [Precision(5,2)]
    public double Width { get; set; }
    
    [Required]
    [Precision(5,2)]
    public double Height { get; set; }
    
    [Required]
    [Precision(5,2)]
    public double Depth { get; set; }
}