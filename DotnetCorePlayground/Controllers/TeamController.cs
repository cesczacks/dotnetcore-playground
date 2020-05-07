using DotnetCorePlayground.Models;
using DotnetCorePlayground.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DotnetCorePlayground.Controllers
{
	/// <summary>
	/// 
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	public class TeamController
	{
		private readonly IDataReader<Team> _teamDataReader;

		public TeamController(IDataReader<Team> teamDataReader)
		{
			_teamDataReader = teamDataReader;
		}

		/// <summary>
		/// Get Team Info By Id
		/// </summary>
		/// <param name="id">The Id column in Team table</param>
		/// <returns>A single Team</returns>
		[HttpGet("{id}")]
		public ActionResult<List<Team>> Get(int id)
		{
			var result = _teamDataReader.ReadAsQueryable()
				.Where(x => x.Id == id)
				.ToList();
			return result;
		}
	}
}
