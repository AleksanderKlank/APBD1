using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Cw10.Models;

[PrimaryKey("IdAccount","IdProduct")]
[Table("Shopping_Carts")]
public class ShoppingCart
{
    [ForeignKey("Account")]
    [Column("FK_account")]
    public int IdAccount { get; set; }

    public Account Account { get; set; }
    
    [ForeignKey("Product")]
    [Column("FK_product")]
    public int IdProduct { get; set; }
    
    public Product Product { get; set; }
    
    [Required]
    [Column("amount")]
    public int Amount { get; set; }
}