using Microsoft.EntityFrameworkCore;

namespace StuffPack.Models
{
    public class PackContext : DbContext
    {
        public PackContext(DbContextOptions<PackContext> options) : base(options) {}

        public DbSet<PackItem> PackItems { get; set; }

        public DbSet<PackList> PackLists { get; set; }
    }
}