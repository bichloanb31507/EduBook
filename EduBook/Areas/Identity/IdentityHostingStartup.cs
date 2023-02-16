[assembly: HostingStartup(typeof(EduBook.Areas.Identity.IdentityHostingStartup))]
namespace EduBook.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}