using System.Globalization;
using Cw10.Context;
using Cw10.Exceptions;
using Cw10.Models;
using Cw10.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace Cw10.Services;

public interface IAccountService
{
    Task<AccountResponse> GetAccountById(int id);
    
}

public class AccountService(Cw10Context context) : IAccountService
{
    public async Task<AccountResponse> GetAccountById(int id)
    {
        var account = await context.Accounts
            .Where(a => a.IdAccount.Equals(id))
            .Select(e=>new AccountResponse(
                e.FirstName,
                e.LastName,
                e.Email,
                e.Phone,
                e.Role.Name,  
                e.ShoppingCarts.Select(e => new ShoppingCartRequest(
                    e.IdProduct,
                    e.Product.Name,
                    e.Amount
                )).ToList())).SingleOrDefaultAsync();

        if (account == null)
        {
            throw new NotFoundException($"Account with given id: {id} does not exist");
        }

        return account;
        
    }
    
    
}