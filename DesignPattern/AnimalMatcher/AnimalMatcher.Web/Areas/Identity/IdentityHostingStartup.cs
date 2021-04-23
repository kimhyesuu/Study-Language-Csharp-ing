using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(AnimalMatcher.Web.Areas.Identity.IdentityHostingStartup))]

namespace AnimalMatcher.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { });
        }
    }
}