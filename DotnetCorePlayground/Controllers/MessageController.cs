using DotnetCorePlayground.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCorePlayground.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MessageController : ControllerBase
	{

		private readonly IMessage _messageService;

		//使用构造器，注入IMessage
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
