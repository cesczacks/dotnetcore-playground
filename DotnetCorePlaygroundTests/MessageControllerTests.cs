using DotnetCorePlayground.Controllers;
using DotnetCorePlayground.Services;
using Moq;
using NUnit.Framework;

namespace DotnetCorePlaygroundTests
{
	[TestFixture]
	public class MessageControllerTests
	{
		[Test]
		public void Test() 
		{
			// ARRANGE
			var mockService = new Mock<IMessage>();
			mockService.Setup(x => x.PrintMessage()).Returns("Controller in tests....");

			var mockController = new MessageController(mockService.Object);

			// ACT
			var result = mockController.GetMessage();

			// ASSERT
			Assert.AreEqual("Controller in tests....", result);
		}
	}
}
