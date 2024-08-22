using Microsoft.EntityFrameworkCore;
namespace SGE.Repositories;

public class FmsSqlite
{
    public static void Initialize()
    {
        using var context = new FmsContext();
        if (!context.Database.EnsureCreated())
        {
            return;
        }
        var connection = context.Database.GetDbConnection();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "PRAGMA journal_mode=DELETE;";
        command.ExecuteNonQuery();
    }
}
