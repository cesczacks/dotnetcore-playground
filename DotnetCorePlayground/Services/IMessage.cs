namespace DotnetCorePlayground.Services
{
	public interface IMessage
	{
		int MessageCount { get; set; }

		IMessage MessageCountIncrement();

		string PrintMessage();
	}
}
