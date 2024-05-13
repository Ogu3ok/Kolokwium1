using System.Data.SqlClient;
using Kolos1.Models;

namespace Kolos1.Repositories;

public class FireActionRepo
{
    private IConfiguration _configuration;
    
    public FireActionRepo(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public FireAction? GetFireAction(int id)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        connection.Open();
        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandText =
            "Select IdFireAction, StartTime, EndTime, NeedSpecialEquipment from FireActon where IdFireAction = @IdFireAction";
        command.Parameters.AddWithValue("@IdFireAction", id);
        
        var dr = command.ExecuteReader();
        if (!dr.Read()) return null;
        var fireAction = new FireAction()
        {
            IdFireAction = (int)dr["IdFireAction"],
            StartTime = (DateTime)dr["StartTime"],
            EndTime = dr["EndTime"] == DBNull.Value ? null : (DateTime?)dr["EndTime"],
            NeedSpecialEquipment = (bool)dr["NeedSpecialEquipment"]
        };
        return fireAction;
    }

    public int DeleteFireAction(int id)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        connection.Open();
        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Delete from FireAction where IdFireAction = @IdFireAction";
        command.Parameters.AddWithValue("@IdFireAction", id);
        
        return command.ExecuteNonQuery();
    }
}