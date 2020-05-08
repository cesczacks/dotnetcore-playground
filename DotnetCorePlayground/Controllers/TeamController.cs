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
		private readonly IDataReader<User> _userDataReader;

		public TeamController(IDataReader<Team> teamDataReader, IDataReader<User> userDataReader)
		{
			_teamDataReader = teamDataReader;
			_userDataReader = userDataReader;
		}

		/// <summary>
		/// Get Team Info By Id
		/// </summary>
		/// <param name="id">The Id column in Team table</param>
		/// <returns>A single Team</returns>
		[HttpGet("{id}")]
		public ActionResult<Team> Get(int id)
		{
			var result = _teamDataReader
				.ReadAsQueryable()
				.FirstOrDefault(x => x.Id == id);

			return result;
		}

		[HttpGet("User")]
		public ActionResult<List<User>> GetAll()
		{
			return _userDataReader.ReadAsQueryable().ToList();
		}
	}
}
