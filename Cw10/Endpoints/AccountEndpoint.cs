using Cw10.Context;
using Cw10.Exceptions;
using Cw10.Services;

namespace Cw10.Endpoints;

public static class AccountEndpoint
{
    public static void RegisterAccountEndpoint(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("accounts");

        group.MapGet("{id:int}", async (int id, IAccountService service) =>
        {
            try
            {
                var result = await service.GetAccountById(id);
                return Results.Ok(result);
            }
            catch(NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}