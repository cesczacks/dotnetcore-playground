using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetCorePlayground.Models
{
	public class Permission : IEntityBase
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public bool Flag { get; set; }
	}

	public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
	{
		public void Configure(EntityTypeBuilder<Permission> builder)
		{
			
		}
	}
}
