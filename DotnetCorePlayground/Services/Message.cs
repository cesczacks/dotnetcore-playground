namespace DotnetCorePlayground.Services
{
	public class Message : IMessage
	{
		public int MessageCount { get; set; }

		public IMessage MessageCountIncrement()
		{
			MessageCount++;
			return this;
		}

		public string PrintMessage() => $"Hello, this is a message from {nameof(Message)}";
		
	}
}
