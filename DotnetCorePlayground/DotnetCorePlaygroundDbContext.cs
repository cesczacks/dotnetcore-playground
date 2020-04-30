using Microsoft.EntityFrameworkCore;

namespace DotnetCorePlayground
{
	public class DotnetCorePlaygroundDbContext : DbContext
	{
		public DotnetCorePlaygroundDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var assemblyWithConfigurations = GetType().Assembly;
			modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
		}
	}
}
