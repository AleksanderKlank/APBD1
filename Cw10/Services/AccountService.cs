using System.Globalization;
using Cw10.Context;
using Cw10.Exceptions;
using Cw10.Models;
using Microsoft.EntityFrameworkCore;

namespace Cw10.Services;

public interface IAccountService
{
    Task<Account> GetAccountById(int id);
}

public class AccountService(Cw10Context context) : IAccountService
{
    public async Task<Account> GetAccountById(int id)
    {
        var account = await context.Accounts.Where(a => a.IdAccount.Equals(id)).SingleOrDefaultAsync();

        if (account == null)
        {
            throw new NotFoundException($"Account with given id: {id} does not exist");
        }

        return account;
    }
}