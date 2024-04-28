using System.Data.SqlClient;
using Cw7.Validators;

namespace Cw7.DTOs;

public static class WarehouseEndpoint
{
    public static void RegisterWarehouseEndpoint(this WebApplication app)
    {
        app.MapPost("api/addWarehouseProduct", (IConfiguration configuration,CreateProductWarehouse request) =>
        {
            var validation = new WarehouseValidator().Validate(request);
            if(!validation.IsValid) Results.ValidationProblem(validation.ToDictionary());
            int idOrder = 1;
            double price = 10;
            
            using (var sqlConnection = new SqlConnection(configuration.GetConnectionString("Default")))
            {
                var sqlCommand =
                    new SqlCommand(
                        "INSERT INTO Product_Warehouse " +
                        "(IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt) " +
                        "values " +
                        "(@idWarehouse,@idProduct,@idOrder,@amount,@price,@createdAt)",
                        sqlConnection);
                sqlCommand.Parameters.AddWithValue("@idWarehouse", request.IdWarehouse);
                sqlCommand.Parameters.AddWithValue("@idProduct", request.IdProduct);
                sqlCommand.Parameters.AddWithValue("@amount", request.Amount);
                sqlCommand.Parameters.AddWithValue("@createdAt", request.CreatedAt);
                sqlCommand.Parameters.AddWithValue("@idOrder", idOrder);
                sqlCommand.Parameters.AddWithValue("@price", price);
                sqlCommand.Connection.Open();

                sqlCommand.ExecuteNonQuery();

                return Results.Created("","Successfully created.");
            }
            
        });
    }
}