using MediatR;
using Sample.Donation.Servers.Databases;

namespace Sample.Donation.Servers.Commands;

// ReSharper disable once UnusedMember.Global
// MediatR will automatically find and use this class somehow, do not remove it!
public class AddDonationCommandHandler : IRequestHandler<AddDonationCommand>
{
    private Database Database { get; }

    public AddDonationCommandHandler(Database database)
    {
        Database = database;
    }

    public async Task Handle(AddDonationCommand request, CancellationToken cancellationToken)
    {
        await Database.AddDonation(request.Donation);
    }
}