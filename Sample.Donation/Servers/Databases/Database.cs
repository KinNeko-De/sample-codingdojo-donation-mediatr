using System.Data.SQLite;

namespace Sample.Donation.Servers.Databases;

public class Database
{
    // The database will be dropped when the connection is closed
    // This is very specific to in-memory databases and only useful for this coding dojo
    private SQLiteConnection? connection;

    private SQLiteConnection Connection => connection ?? throw new InvalidOperationException("Call Initialize to create the database");

    public async Task Initialize()
    {
        connection = await GetOpenConnection();
        await CreateTable();
    }

    private static async Task<SQLiteConnection> GetOpenConnection()
    {
        // The database will be dropped when the connection is closed
        var connection = new SQLiteConnection("Data Source=:memory:; Version = 3;");
        await connection.OpenAsync();
        return connection;
    }

    private async Task CreateTable()
    {
        const string createSql = "CREATE TABLE Donations(Total INT)";
        await using var sqliteCmd = Connection.CreateCommand();
        sqliteCmd.CommandText = createSql;
        await sqliteCmd.ExecuteNonQueryAsync();
    }

    public async Task Seed(DatabaseConfig config)
    {
        await using var command = Connection.CreateCommand();
        command.CommandText = "INSERT INTO Donations(Total) VALUES($total);";
        command.Parameters.AddWithValue("$total", config.InitialDonationsTotal);
        await command.ExecuteNonQueryAsync();
    }

    public async Task<int> GetTotalDonations()
    {
        await using var command = Connection.CreateCommand();
        command.CommandText = "SELECT Total FROM Donations";
        var result = await command.ExecuteScalarAsync();
        return result is DBNull ? 0 : Convert.ToInt32(result);
    }

    public async Task AddDonation(int donation)
    {
        await using var command = Connection.CreateCommand();
        command.CommandText = "UPDATE Donations SET Total = Total + $donation";
        command.Parameters.AddWithValue("$donation", donation);
        await command.ExecuteNonQueryAsync();
    }
}
