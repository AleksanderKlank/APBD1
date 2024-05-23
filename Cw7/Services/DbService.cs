using System.Data;
using System.Data.SqlClient;
using Cw7.DTOs;

namespace Cw7.Services;

public interface IDbService
{
    Task<CreateProductWarehouse> AddWarehouseProduct(CreateProductWarehouse request, int orderId, int price);
    Task<int> CountWarehouse(int id);
    Task<int> GetOrderID(int id, int amount);
    Task<int> ProductWarehouseCount(int id);
    Task<int> CheckPrice(int id);
}


public class DbService(IConfiguration configuration) : IDbService
{
    // Helper method for creating and opening connection
    private async Task<SqlConnection> GetConnection()
    {
        var connection = new SqlConnection(configuration.GetConnectionString("Default"));
        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        return connection;
    }

    public async Task<CreateProductWarehouse> AddWarehouseProduct(CreateProductWarehouse request, int orderId, int price)
    {
        var sqlConnection = await GetConnection();
        await using var transaction = await sqlConnection.BeginTransactionAsync();
        // Wstawienie rekordu do tabeli Product_Warehouse
        try
        {
            var sqlCommand6 = new SqlCommand(
                @"INSERT INTO Product_Warehouse (IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt) 
                        VALUES (@warehouseId, @productId, @orderId, @amount, @price, @createdAt);
                        select cast(scope_identity() as int)"
                , sqlConnection,(SqlTransaction)transaction);
            sqlCommand6.Parameters.AddWithValue("@warehouseId", request.IdWarehouse);
            sqlCommand6.Parameters.AddWithValue("@productId", request.IdProduct);
            sqlCommand6.Parameters.AddWithValue("@orderId", orderId);
            sqlCommand6.Parameters.AddWithValue("@amount", request.Amount);
            sqlCommand6.Parameters.AddWithValue("@price", request.Amount * price);
            sqlCommand6.Parameters.AddWithValue("@createdAt", DateTime.UtcNow);
            var studentId = (int)await sqlCommand6.ExecuteNonQueryAsync();
            await transaction.CommitAsync();
            
            return request;
        }
        catch (Exception) 
        { 
            await transaction.RollbackAsync(); 
            throw; 
        }
        
    }

    public async Task<int> CountWarehouse(int id)
    {
        // Sprawdzanie istnienia magazynu
        var sqlConnection = await GetConnection();
        var sqlCommand = new SqlCommand("SELECT COUNT(1) FROM Warehouse WHERE IdWarehouse = @idWarehouse", sqlConnection);
        sqlCommand.Parameters.AddWithValue("@idWarehouse", id);
        return (int)await sqlCommand.ExecuteScalarAsync();
    }

    public async Task<int> GetOrderID(int id, int amount)
    {
        // Sprawdzanie istnienia zamówienia
        var sqlConnection = await GetConnection();
        var sqlCommand = new SqlCommand("SELECT IdOrder FROM [Order] WHERE IdProduct = @idProduct AND Amount = @amount", sqlConnection);
        sqlCommand.Parameters.AddWithValue("@idProduct", id);
        sqlCommand.Parameters.AddWithValue("@amount", amount);
        var result = await sqlCommand.ExecuteScalarAsync();
        int orderId = result == null ? 0 : (int)result;
        return orderId;
    }

    public async Task<int> ProductWarehouseCount(int id)
    {
        // Sprawdzanie, czy zamówienie zostało zrealizowane
        var sqlConnection = await GetConnection();  
        var sqlCommand = new SqlCommand("SELECT COUNT(*) FROM Product_Warehouse WHERE IdOrder = @orderId", sqlConnection);
        sqlCommand.Parameters.AddWithValue("@orderId", id);
        return (int)await sqlCommand.ExecuteScalarAsync();
    }

    public async Task<int> CheckPrice(int id)
    {
        var sqlConnection = await GetConnection();
        var sqlCommand5 = new SqlCommand("Select Price FROM Product WHERE IdProduct = @idProduct", sqlConnection);
        sqlCommand5.Parameters.AddWithValue("@idProduct", id);
        return await sqlCommand5.ExecuteNonQueryAsync();
    }
}