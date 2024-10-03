using Sample.Donation.Servers.Databases;

namespace Sample.Donation.Servers;

public class Server
{
    private Database Database { get; }

    public Server(Database database)
    {
        Database = database;
    }

    public async Task<int> UpdateDonation(int donation)
    {
        await Database.AddDonation(donation);
        return await Database.GetTotalDonations();
    }
}
