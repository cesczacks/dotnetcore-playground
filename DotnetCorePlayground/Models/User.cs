﻿namespace DotnetCorePlayground.Models
{
	public class User : IEntityBase
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Gender { get; set; }
	}
}
