using Microsoft.EntityFrameworkCore;

namespace Gruppe2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PollenResponse> PollenResponses { get; set; }
        public DbSet<DateInfo> Dateinfos { get; set; }
        public DbSet<PlantInfo> Plantinfos { get; set; }
        public DbSet<IndexInfo> IndexInfos { get; set; }
        public DbSet<ColorInfo> Colorinfos { get; set; }
        public DbSet<PollenRegistrering> PollenRegistreringer { get; set; }
    }
}
