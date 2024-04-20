using System;

namespace LegacyApp;

public class UserCreditServiceAdapter : IUserCreditService
{
    private readonly UserCreditService _userCreditService;

    public UserCreditServiceAdapter(UserCreditService userCreditService)
    {
        _userCreditService = userCreditService;
    }

    public int GetCreditLimit(string lastName, DateTime dateOfBirth)
    {
        return _userCreditService.GetCreditLimit(lastName, dateOfBirth);
    }
}
