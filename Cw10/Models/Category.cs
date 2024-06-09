using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cw10.Models;

[Table("Categories")]
public class Category
{
    [Key]
    [Column("PK_category")]
    public int IdCategory { get; set; }
    
    [MaxLength(100)]
    [Required]
    [Column("name")]
    public string Name { get; set; }

    public IEnumerable<ProductsCategories> ProductsCategoriesEnumerable { get; set; }
    

}