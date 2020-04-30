using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetCorePlayground.Models
{
	public class User : IEntityBase
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Gender { get; set; }
	}

	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(x => x.Id);
		}
	}
}
