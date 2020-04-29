using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace DotnetCorePlayground.Models
{
	public class Team : IEntityBase
	{
		public int Id { get; set; }

		public string Name { get; set; }
	}

	public class TeamConfiguration : IEntityTypeConfiguration<Team>
	{
		public void Configure(EntityTypeBuilder<Team> builder)
		{
			builder.HasAlternateKey(x => new
			{
				x.Id,
				x.Name
			});

			builder.Property(x => x.Id).IsRequired().HasMaxLength(50);

			builder.HasData(new List<Team>
			{
				new Team
				{
					Id = 1,
					Name = "Arsenal"
				},
				new Team
				{
					Id = 2,
					Name = "Liverpool"
				}
			});
		}
	}
}
