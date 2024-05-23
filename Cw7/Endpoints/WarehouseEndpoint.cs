using Cw7.DTOs;
using Cw7.Services;
using FluentValidation;

namespace Cw7.Endpoints;
using System.Data.SqlClient;
using Cw7.Validators;


public static class WarehouseEndpoint
{
    public static void RegisterWarehouseEndpoint(this WebApplication app)
    {

        var warehouseProduct = app.MapGroup("api/addWarehouseProduct");
        warehouseProduct.MapPost("", AddWarehouseProduct);
    }
    // app.MapPost("api/addWarehouseProduct", async (IConfiguration configuration, CreateProductWarehouse request) =>
        //     {
        //         var warehouseCount = 0;
        //         int orderId = 0;
        //         var validation = new WarehouseValidator().Validate(request); 
        //         if (!validation.IsValid) return Results.ValidationProblem(validation.ToDictionary());
        //
        //         using (var sqlConnection = new SqlConnection(configuration.GetConnectionString("Default")))
        //         {
        //             await sqlConnection.OpenAsync();
        //
        //             // Sprawdzanie istnienia magazynu
        //             var sqlCommand1 = new SqlCommand("SELECT COUNT(1) FROM Warehouse WHERE IdWarehouse = @idWarehouse", sqlConnection);
        //             sqlCommand1.Parameters.AddWithValue("@idWarehouse", request.IdWarehouse);
        //             warehouseCount = (int)await sqlCommand1.ExecuteScalarAsync();
        //             if (warehouseCount < 1) return Results.BadRequest("Invalid Warehouse Id.");
        //
        //             // Sprawdzanie istnienia zamówienia
        //             var sqlCommand2 = new SqlCommand("SELECT IdOrder FROM [Order] WHERE IdProduct = @idProduct AND Amount = @amount", sqlConnection);
        //             sqlCommand2.Parameters.AddWithValue("@idProduct", request.IdProduct);
        //             sqlCommand2.Parameters.AddWithValue("@amount", request.Amount);
        //             var result = await sqlCommand2.ExecuteScalarAsync();
        //             orderId = result == null ? 0 : (int)result;
        //             if (orderId < 1) return Results.BadRequest("Order not found or invalid.");
        //
        //             // Sprawdzanie, czy zamówienie zostało zrealizowane
        //             var sqlCommand3 = new SqlCommand("SELECT COUNT(*) FROM Product_Warehouse WHERE IdOrder = @orderId", sqlConnection);
        //             sqlCommand3.Parameters.AddWithValue("@orderId", orderId);
        //             var fulfilledCount = (int)await sqlCommand3.ExecuteScalarAsync();
        //             if (fulfilledCount > 0) return Results.BadRequest("Order already fulfilled.");
        //
        //             // Aktualizacja daty realizacji zamówienia
        //             var sqlCommand4 = new SqlCommand("UPDATE [Order] SET FulfilledAt = GETDATE() WHERE IdOrder = @orderId", sqlConnection);
        //             sqlCommand4.Parameters.AddWithValue("@orderId", orderId);
        //             await sqlCommand4.ExecuteNonQueryAsync();
        //             
        //             // Sprawdzenie ceny produktu
        //             var sqlCommand5 = new SqlCommand("Select Price FROM Product WHERE IdProduct = @idProduct", sqlConnection);
        //             sqlCommand5.Parameters.AddWithValue("@idProduct", request.IdProduct);
        //             var price = await sqlCommand5.ExecuteNonQueryAsync();
        //             // Wstawienie rekordu do tabeli Product_Warehouse
        //             
        //             var sqlCommand6 = new SqlCommand("INSERT INTO Product_Warehouse (IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt) " +
        //                                             "VALUES (@warehouseId, @productId, @orderId, @amount, @price, @createdAt)", sqlConnection);
        //             sqlCommand6.Parameters.AddWithValue("@warehouseId", request.IdWarehouse);
        //             sqlCommand6.Parameters.AddWithValue("@productId", request.IdProduct);
        //             sqlCommand6.Parameters.AddWithValue("@orderId", orderId);
        //             sqlCommand6.Parameters.AddWithValue("@amount", request.Amount);
        //             sqlCommand6.Parameters.AddWithValue("@price", request.Amount * price);
        //             sqlCommand6.Parameters.AddWithValue("@createdAt", DateTime.UtcNow);
        //             await sqlCommand6.ExecuteNonQueryAsync();
        //         }
        //
        //         return Results.Created("", "Successfully created.");
        //     });
    

    private static async Task<IResult> AddWarehouseProduct(
        CreateProductWarehouse request,
        IConfiguration configuration,
        IDbService db)
    {
        var validation = new WarehouseValidator().Validate(request); 
        if (!validation.IsValid) return Results.ValidationProblem(validation.ToDictionary());

        // Sprawdzanie istnienia magazynu
        var warehouseCount = await db.CountWarehouse(request.IdWarehouse);
        if (warehouseCount <= 0)
            return Results.NotFound("Invalid Warehouse Id.");

        // Sprawdzanie istnienia zamówienia
        var idOrder = await db.GetOrderID(request.IdProduct, request.Amount);
        if (idOrder <= 0)
            return Results.NotFound("Order not found or invalid.");

        // Sprawdzanie, czy zamówienie zostało zrealizowane
        var fulfilledCount = await db.ProductWarehouseCount(idOrder);
        if (fulfilledCount > 0) 
            return Results.NotFound("Order already fulfilled.");

        // Sprawdzenie ceny produktu
        var price = await db.CheckPrice(idOrder);

        var added = await db.AddWarehouseProduct(request, idOrder, price);
        
        return Results.Created();
    }

    
}
