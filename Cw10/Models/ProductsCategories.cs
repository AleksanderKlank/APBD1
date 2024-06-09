using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Cw10.Models;


[PrimaryKey("IdCategory","IdProduct")]
[Table("Products_Categories")]
public class ProductsCategories
{
    [ForeignKey("Category")]
    [Column("FK_category")]
    public int IdCategory { get; set; }
    public Category Category { get; set; }
    
    [ForeignKey("Product")]
    [Column("FK_product")]
    public int IdProduct { get; set; }
    public Product Product { get; set; }
}