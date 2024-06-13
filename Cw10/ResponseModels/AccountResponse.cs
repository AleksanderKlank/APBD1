using Cw10.Models;


namespace Cw10.ResponseModels;

public record AccountResponse(
    string firstName,
    string lastName,
    string email,
    string phone,
    string role,
    List<ShoppingCartRequest> cart
    );
public record ShoppingCartRequest(int productId, string productName, int amount );