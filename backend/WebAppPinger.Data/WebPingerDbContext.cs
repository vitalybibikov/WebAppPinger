using Microsoft.EntityFrameworkCore;
using WebAppPinger.Data.Entities;

namespace WebAppPinger.Data
{
    public class WebPingerDbContext : DbContext
    {
        public WebPingerDbContext(DbContextOptions<WebPingerDbContext> options)
            : base(options)
        {
        }

        public DbSet<EndpointEntity> Endpoints { get; set; }
    }
}