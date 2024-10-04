using MagniseTask.Models;
using Microsoft.EntityFrameworkCore;

namespace MagniseTask.Data
{
    public class MagniseContext : DbContext
    {
        public MagniseContext(DbContextOptions<MagniseContext> options) : base(options) { }

        public DbSet<MarketAsset> MarketAssets { get; set; }
        public DbSet<PriceInfo> PriceInfos { get; set; }
    }
}
