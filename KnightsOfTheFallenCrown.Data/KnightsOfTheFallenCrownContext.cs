using KnightsOfTheFallenCrown.Core.Domain;
using KnightsOfTheFallenCrown.Core.Dto;
using Microsoft.EntityFrameworkCore;

namespace KnightsOfTheFallenCrown.Data
{
    public class KnightsOfTheFallenCrownContext : DbContext
    {
        public KnightsOfTheFallenCrownContext(DbContextOptions<KnightsOfTheFallenCrownContext> options) : base(options) { }
        public DbSet<Knight> Knights { get; set; }
        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
    }
}
