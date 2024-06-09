using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Cw10.Models;


[PrimaryKey(nameof(IdCategory),nameof(IdProduct))]
[Table("Products_Categories")]
public class ProductsCategories
{
    [ForeignKey(nameof(Category))]
    [Column("FK_category")]
    public int IdCategory { get; set; }
    public Category Category { get; set; }
    
    [ForeignKey(nameof(Product))]
    [Column("FK_product")]
    public int IdProduct { get; set; }
    public Product Product { get; set; }
}