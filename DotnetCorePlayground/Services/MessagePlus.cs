namespace DotnetCorePlayground.Services
{
	public class MessagePlus : IMessage
	{
		public int MessageCount { get; set; }

		public IMessage MessageCountIncrement()
		{
			MessageCount++;
			return this;
		}

		public string PrintMessage() => $"Hello, this is a message from {nameof(MessagePlus)}";
	}
}
