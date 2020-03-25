using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCorePlayground.Services
{
	public interface IMessage
	{
		int MessageCount { get; set; }

		void MessageCountIncrement();

		string PrintMessage();
	}
}
