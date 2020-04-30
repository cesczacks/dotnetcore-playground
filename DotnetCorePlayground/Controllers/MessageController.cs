using DotnetCorePlayground.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCorePlayground.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MessageController : ControllerBase
	{

		private readonly IMessage _messageService;

		// 使用构造器，注入IMessage
		public MessageController(IMessage messageService)
		{
			_messageService = messageService;
		}

		[HttpGet("GetMessage")]
		public string GetMessage()
		{
			return _messageService.PrintMessage();
		}

		[HttpGet("GetMessageCount")]
		public int GetMessageCount() 
		{
			return _messageService.MessageCountIncrement().MessageCount;
		}
	}
}
