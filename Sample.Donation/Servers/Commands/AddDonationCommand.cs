using MediatR;

namespace Sample.Donation.Servers.Commands;

public class AddDonationCommand : IRequest
{
    public required int Donation { get; init; }
}