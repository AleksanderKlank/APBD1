using Cw10.Context;
using Cw10.Exceptions;
using Cw10.Models;
using Cw10.RequestModels;
using Microsoft.EntityFrameworkCore;

namespace Cw10.Services;

public interface IProductService
{
    Task PostProduct(PostProductModel model);
    
}

public class ProductService(Cw10Context context) : IProductService
{
    public async Task PostProduct(PostProductModel model)
    {
        var product = new Product
        {
            Name = model.ProductName,
            Weight = model.ProductWeight,
            Width = model.ProductWidth,
            Height = model.ProductHeight,
            Depth = model.ProductDepth,
        };

        var categories= await context.Categories
            .Where(e1 => model.ProductCategories.Any(e2 => e2.Equals(e1.IdCategory)))
            .Select(e=>e.IdCategory)
            .ToListAsync();


        model.ProductCategories.ForEach(e =>
        { 
            if (!categories.Contains(e)) 
            { 
                throw new NotFoundException($"Category with given id: {e} does not exist");
            }
        });
        
        var productCategories = model.ProductCategories.Select(e => new ProductsCategories()
        {
            Product = product,
            IdCategory = e
        });
        await context.ProductsCategories.AddRangeAsync(productCategories);

        await context.SaveChangesAsync();
        
    }
}