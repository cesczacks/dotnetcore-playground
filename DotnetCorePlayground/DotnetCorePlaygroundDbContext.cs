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
	}
}
