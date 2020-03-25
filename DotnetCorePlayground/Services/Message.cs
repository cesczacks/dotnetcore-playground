using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCorePlayground.Services
{
	public class Message : IMessage
	{
		public int MessageCount { get; set; }

		public void MessageCountIncrement()
		{
			MessageCount++;
		}

		public string PrintMessage() => $"Hello, this is a message from {nameof(Message)}";
		
	}
}
