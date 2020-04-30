using System.Collections.Generic;
using System.Linq;
using DotnetCorePlayground.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCorePlayground.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class TeamController
	{
		private readonly DotnetCorePlaygroundDbContext _context;

		public TeamController(DotnetCorePlaygroundDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Get Team Info By Id
		/// </summary>
		/// <param name="id">The Id column in Team table</param>
		/// <returns>A single Team</returns>
		[HttpGet("{id}")]
		public ActionResult<List<Team>> Get(int id)
		{
			var dataSet = _context.Set<Team>();

			var result = dataSet.Where(x => x.Id == id).ToList();

			return result;
		}
	}
}
