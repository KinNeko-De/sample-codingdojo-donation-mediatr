using MediatR;

namespace Sample.Donation.Servers.Queries;

public class GetTotalDonationsQuery : IRequest<int>;