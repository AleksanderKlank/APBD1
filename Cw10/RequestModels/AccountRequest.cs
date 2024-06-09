namespace Cw10.RequestModels;

public record AccountRequest(
    int idRole, 
    string firstName, 
    string lastName, 
    string email, 
    string? phone, 
    ICollection<ShoppingCartRequest> shoppingCarts
    );