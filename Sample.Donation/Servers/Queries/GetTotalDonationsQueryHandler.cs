using MediatR;
using Sample.Donation.Servers.Databases;

namespace Sample.Donation.Servers.Queries;

// ReSharper disable once UnusedMember.Global
// MediatR will automatically find and use this class somehow, do not remove it!
public class GetTotalDonationsQueryHandler : IRequestHandler<GetTotalDonationsQuery, int>
{
    private Database Database { get; }

    public GetTotalDonationsQueryHandler(Database database)
    {
        Database = database;
    }

    public async Task<int> Handle(GetTotalDonationsQuery request, CancellationToken cancellationToken)
    {
        return await Database.GetTotalDonations();
    }
}
