using Cw10.Models;
using Cw10.RequestModels;

namespace Cw10.ResponseModels;

public record AccountResponse(
    string firstName,
    string lastName,
    string email,
    string phone,
    string role,
    List<ShoppingCartRequest> cart
    );