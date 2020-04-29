using System.Reflection;
using DotnetCorePlayground.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetCorePlayground
{
	public class DotnetCorePlaygroundDbContext : DbContext
	{
		public DbSet<User> User { get; set; }

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
