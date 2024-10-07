using MediatR;
using Sample.Donation.Servers.Commands;
using Sample.Donation.Servers.Queries;

namespace Sample.Donation.Servers;

public class Server
{
    public ISender Sender { get; }

    public Server(ISender sender)
    {
        Sender = sender;
    }

    public async Task<int> UpdateDonation(int donation)
    {
        var command = new AddDonationCommand() { Donation = donation };
        await Sender.Send(command);

        var query = new GetTotalDonationsQuery();
        return await Sender.Send(query);
    }
}