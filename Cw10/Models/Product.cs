using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Cw10.Models;

[Table("Products")]
public class Product
{
    [Key]
    [Column("PK_product")]
    public int IdProduct { get; set; }
    
    [Required]
    [MaxLength(100)]
    [Column("name")]
    public string Name { get; set; }
    
    [Required]
    [Column("weight", TypeName="decimal(5,2)")]
    public double Weight { get; set; }
    
    [Required]
    [Column("width", TypeName="decimal(5,2)")]
    public double Width { get; set; }
    
    [Required]
    [Column("height", TypeName="decimal(5,2)")]
    public double Height { get; set; }
    
    [Required]
    [Column("depth", TypeName="decimal(5,2)")]
    public double Depth { get; set; }
    
    public ICollection<ProductsCategories> ProductsCategories { get; set; }
    public ICollection<ShoppingCart> ShoppingCarts { get; set; }
    
}