using System.Data.SqlClient;

namespace Cw6.Endpoints;

public static class AnimalsEndpoints
{
    public static void RegisterAnimalsEndpoints(this WebApplication app)
    {
        app.MapGet("api/animals/all", (IConfiguration configuration) =>
        {
            var animals = new List<GetAllAnimalsResponse>();
            using (var sqlConnection = new SqlConnection(configuration.GetConnectionString("Default")))
            {
                var sqlCommand = new SqlCommand("SELECT * from Animal", sqlConnection);
                sqlCommand.Connection.Open();
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    animals.Add(new GetAllAnimalsResponse(
                            Id: reader.GetInt32(0),
                            Name: reader.GetString(1),
                            Description: reader.GetString(2),
                            Category: reader.GetString(3),
                            Area: reader.GetString(4)
                        )
                    );
                }
            }

            return Results.Ok(animals);
        });

        app.MapGet("api/animals/{id:int}", (IConfiguration configuration, int id) =>
        {
            var animals = new List<GetAllAnimalsResponse>();
            using (var sqlConnection = new SqlConnection(configuration.GetConnectionString("Default")))
            {
                var sqlCommand = new SqlCommand("SELECT * from Animal WHERE Animal.IdAnimal = @id", sqlConnection);

                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.Connection.Open();

                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    animals.Add(new GetAllAnimalsResponse(
                            Id: reader.GetInt32(0),
                            Name: reader.GetString(1),
                            Description: reader.GetString(2),
                            Category: reader.GetString(3),
                            Area: reader.GetString(4)
                        )
                    );
                }
            }

            return Results.Ok(animals);
        });

        app.MapGet("api/animals/{orderBy?}", (IConfiguration configuration, string? orderBy) =>
        {
            var allowedColumns = new List<string> { "Name", "Description", "Category", "Area" };
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "Name";
            }

            if (!allowedColumns.Contains(orderBy))
            {
                return Results.BadRequest("Invalid order by parameter.");
            }

            var animals = new List<GetAllAnimalsResponse>();
            using (var sqlConnection = new SqlConnection(configuration.GetConnectionString("Default")))
            {
                var sqlCommandText = $"SELECT * from Animal ORDER BY {orderBy}";
                var sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);

                sqlCommand.Connection.Open();

                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    animals.Add(new GetAllAnimalsResponse(
                            Id: reader.GetInt32(0),
                            Name: reader.GetString(1),
                            Description: reader.GetString(2),
                            Category: reader.GetString(3),
                            Area: reader.GetString(4)
                        )
                    );
                }
            }

            return Results.Ok(animals);
        });

        app.MapPost("api/animals", (IConfiguration configuration, CreateAnimalRequest request) =>
        {
            var validation = new AnimalValidator().Validate(request);
            if (!validation.IsValid) return Results.ValidationProblem(validation.ToDictionary());

            using (var sqlConnection = new SqlConnection(configuration.GetConnectionString("Default")))
            {
                var sqlCommand =
                    new SqlCommand("INSERT INTO Animal (Name, Description, Category, Area) values (@n, @d, @c, @a)",
                        sqlConnection);
                sqlCommand.Parameters.AddWithValue("@n", request.Name);
                sqlCommand.Parameters.AddWithValue("@d", request.Description);
                sqlCommand.Parameters.AddWithValue("@c", request.Category);
                sqlCommand.Parameters.AddWithValue("@a", request.Area);
                sqlCommand.Connection.Open();

                sqlCommand.ExecuteNonQuery();

                return Results.Created("", null);
            }
        });

        app.MapPut("/api/animals/{idAnimal}", (IConfiguration configuration, CreateAnimalRequest request, int idAnimal) =>
                {
                    var validation = new AnimalValidator().Validate(request);
                    if (!validation.IsValid) return Results.ValidationProblem(validation.ToDictionary());

                    using (var sqlConnection = new SqlConnection(configuration.GetConnectionString("Default")))
                    {
                        var sqlCommand = new SqlCommand("UPDATE Animal SET Name = @n, Description = @d, Area = @a, Category = @c Where IdAnimal = @idAnimal",sqlConnection);
                        sqlCommand.Parameters.AddWithValue("@n", request.Name);
                        sqlCommand.Parameters.AddWithValue("@d", request.Description);
                        sqlCommand.Parameters.AddWithValue("@c", request.Category);
                        sqlCommand.Parameters.AddWithValue("@a", request.Area);
                        sqlCommand.Parameters.AddWithValue("@idAnimal", idAnimal);
                        sqlCommand.Connection.Open();

                        var result = sqlCommand.ExecuteNonQuery();

                        if (result > 0)
                        {
                            return Results.Ok($"Record with ID {idAnimal} has been successfully updated.");
                        }
                        
                        return Results.NotFound($"Record with ID {idAnimal} not found.");
                    }
                });
        
        app.MapDelete("/api/animals/{idAnimal}", async (IConfiguration configuration, int idAnimal) =>
        {
            
            using (var sqlConnection = new SqlConnection(configuration.GetConnectionString("Default")))
            {
                try
                {
                    await sqlConnection.OpenAsync();
                    using (var sqlCommand = new SqlCommand("DELETE FROM Animal WHERE IdAnimal = @idAnimal", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@idAnimal", idAnimal);

                        var result = await sqlCommand.ExecuteNonQueryAsync();
                
                        if (result > 0)
                        {
                            return Results.Ok($"Record with ID {idAnimal} has been successfully deleted.");
                        }
                        
                        return Results.NotFound($"Record with ID {idAnimal} not found.");
                    }
                }
                catch (Exception ex)
                {
                    return Results.Problem("An error occurred while processing your request: " + ex.Message);
                }
            }
        });

        
    }
}