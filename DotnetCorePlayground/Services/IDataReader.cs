using System.Linq;

namespace DotnetCorePlayground.Services
{
	public interface IDataReader<out T> where T : class
	{
		public IQueryable<T> ReadAsQueryable();
	}
}
