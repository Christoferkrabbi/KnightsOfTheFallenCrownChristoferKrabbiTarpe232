using KnightsOfTheFallenCrown.Core.Domain;
using KnightsOfTheFallenCrown.Core.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KnightsOfTheFallenCrown.Data
{
	public class KnightsOfTheFallenCrownContext : IdentityDbContext<ApplicationUser>
	{
		public KnightsOfTheFallenCrownContext(DbContextOptions<KnightsOfTheFallenCrownContext> options) : base(options) { }
		public DbSet<Knight> Knights { get; set; }
		public DbSet<FileToDatabase> FilesToDatabase { get; set; }
		public DbSet<IdentityRole> IdentityRoles { get; set; }
	}
}
//gotta make an users branch: I did:)