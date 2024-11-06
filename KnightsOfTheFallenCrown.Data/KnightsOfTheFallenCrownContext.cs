using KnightsOfTheFallenCrown.Core.Dto;
using Microsoft.EntityFrameworkCore;

namespace KnightsOfTheFallenCrown.Data
{
    public class KnightsOfTheFallenCrownContext
    {
        public DbSet<Knight> Knights { get; set; }
    }
}
