using KnightsOfTheFallenCrown.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace KnightsOfTheFallenCrown.Data
{
    public class KnightsOfTheFallenCrownContext
    {
        public DbSet<Knights> Knight { get; set; }
    }
}
