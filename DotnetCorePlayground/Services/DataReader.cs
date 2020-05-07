using System.Linq;

namespace DotnetCorePlayground.Services
{
	public class DataReader<T> : IDataReader<T>
		where T : class
	{
		private readonly DotnetCorePlaygroundDbContext _context;

		public DataReader(DotnetCorePlaygroundDbContext context)
		{
			_context = context;
		}

		public IQueryable<T> ReadAsQueryable()
		{
			var result = _context.Set<T>();

			return result.AsQueryable();
		}
	}
}
