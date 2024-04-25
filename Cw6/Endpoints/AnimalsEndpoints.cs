using System.Data;
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
            var allowedColumns = new List<string> { "IdAnimal", "Name", "Description", "Category", "Area" };
            if (orderBy == null)
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
        
        app.MapPost("api/AddAnimals", (IConfiguration configuration, CreateAnimalRequest request) =>
        {
            // var validation = validator.Validate(request);
            // if (!validation.IsValid) return Results.ValidationProblem(validation.ToDictionary());
            
            using (var sqlConnection = new SqlConnection(configuration.GetConnectionString("Default")))
            {
                var sqlCommand = new SqlCommand("INSERT INTO Animal (Name, Description, Category, Area) values (@fn, @ln, @ph, @bd)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@fn", request.Name);
                sqlCommand.Parameters.AddWithValue("@ln", request.Description);
                sqlCommand.Parameters.AddWithValue("@ph", request.Category);
                sqlCommand.Parameters.AddWithValue("@bd", request.Area);
                sqlCommand.Connection.Open();
                
                sqlCommand.ExecuteNonQuery();
        
                return Results.Created("", null);
            }
        });
    }
}