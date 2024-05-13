using System.Data.SqlClient;
using Kolos1.Models;

namespace Kolos1.Repositories;

public class FireFighterRepo
{
    private IConfiguration _configuration;
    
    public FireFighterRepo(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Firefighter GetFirefighter(int id)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        connection.Open();
        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandText =
            "Select IdFirefighter, FirstName, LastName from FireActon where Firefighter = @IdFirefighter";
        command.Parameters.AddWithValue("@IdFirefighter", id);
        var dr = command.ExecuteReader();
        if (!dr.Read()) return null;

        Firefighter firefighter = new Firefighter()
        {
            IdFirefighter = (int)dr["IdFirefighter"],
            FirstName = (string)dr["FirstName"],
            LastName = (string)dr["LastName"]
        };
        return firefighter;
    }
}