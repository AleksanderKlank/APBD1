using Cw10.Exceptions;
using Cw10.RequestModels;
using Cw10.Services;
using Cw10.Validators;
using FluentValidation;

namespace Cw10.Endpoints;

public static class ProductEndpoint
{
    public static void RegisterProductEndpoint(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("products");
        
        group.MapPost("", async (PostProductModel data, IProductService service) =>
        {
            var validator = new PostProductModelValidator();
            var validate = await validator.ValidateAsync(data);
            if (!validate.IsValid)
            {
                return Results.ValidationProblem(validate.ToDictionary());
            }
    
            try
            {
                await service.PostProduct(data);
                return Results.Created();
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}