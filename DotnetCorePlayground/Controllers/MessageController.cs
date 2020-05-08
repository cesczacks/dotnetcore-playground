using DotnetCorePlayground.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DotnetCorePlayground.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MessageController : ControllerBase
	{

		private readonly IMessage _messageService;

		private readonly IConfiguration _configuration;

		// 使用构造器，注入IMessage
		public MessageController(IMessage messageService, IConfiguration configuration)
		{
			_messageService = messageService;
			_configuration = configuration;
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
