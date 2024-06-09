using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Cw10.Models;

[PrimaryKey(nameof(IdAccount),nameof(IdProduct))]
[Table("Shopping_Carts")]
public class ShoppingCart
{
    [ForeignKey(nameof(Account))]
    [Column("FK_account")]
    public int IdAccount { get; set; }

    public Account Account { get; set; }
    
    [ForeignKey(nameof(Product))]
    [Column("FK_product")]
    public int IdProduct { get; set; }
    
    public Product Product { get; set; }
    
    [Required]
    [Column("amount")]
    public int Amount { get; set; }
}