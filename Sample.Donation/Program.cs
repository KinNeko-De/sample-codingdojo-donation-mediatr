using Sample.Donation.Servers;
using Sample.Donation.Servers.Databases;
using Sample.Donation.UserInterfaces;

namespace Sample.Donation;
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddSingleton<Database>();
        builder.Services.AddTransient<Server>();

        var app = builder.Build();

        var database = app.Services.GetRequiredService<Database>();

        await database.Initialize();

        await database.Seed(new DatabaseConfig());

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
        }

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
