using Sample.Donation.Servers;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Components;

namespace Sample.Donation.UserInterfaces;

public partial class Donation
{
    [Inject] public Server Server { get; set; } = default!;

    public int Total { get; set; }

    public int MyDonation { get; set; }
    public bool AlreadyDonated { get; set; }

    public string DonateText => AlreadyDonated ? "Donate more" : "Donate";

    private async Task Donate()
    {
        Total = await Server.UpdateDonation(MyDonation);
        AlreadyDonated = true;
        MyDonation = 0;
    }
}