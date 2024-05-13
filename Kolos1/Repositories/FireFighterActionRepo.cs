using System.Data.SqlClient;
using Kolos1.Models;

namespace Kolos1.Repositories;

public class FireFighterActionRepo
{
    private IConfiguration _configuration;
    
    public FireFighterActionRepo(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public IEnumerable<FirefighterAction> GetFireFighterAction(int id)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        connection.Open();
        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandText =
            "Select IdAction, IdFirefightert from Firefighter_Acton where IdFireAction = @IdFireAction";
        command.Parameters.AddWithValue("@IdFireAction", id);
        
        var dr = command.ExecuteReader();
        var fireFighterActions = new List<FirefighterAction>();
        while (dr.Read())
        {
            var fireFighterAction = new FirefighterAction()
            {
                IdAction = (int)dr["IdAction"],
                IdFirefighter = (int)dr["IdFirefighter"]
            };
            fireFighterActions.Add(fireFighterAction);
        }
        return fireFighterActions;
    }
}