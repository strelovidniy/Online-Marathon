using NUnit.Framework;
using ShoppingSystem.Controllers;
using ShoppingSystem.Services;
using Moq;
using ShoppingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ShoppingSystem.Test
{
	public class SupermarketsControllerTest
	{
		Mock<ISupermarkets> _supermarketsServiceMock;
		SupermarketsController _supermarketsController;

		[SetUp]
		public void SetUp()
		{
			_supermarketsServiceMock = new Mock<ISupermarkets>();
			_supermarketsController = new SupermarketsController(_supermarketsServiceMock.Object);
		}

		[Test]
		public void DetailsReturnsViewTest()
		{
			_supermarketsServiceMock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
				.ReturnsAsync(new Supermarket() { Id = 1 });

			var result = _supermarketsController.Details(1).Result;
			Assert.AreEqual(typeof(ViewResult), result.GetType());
		}

		[Test]
		public void DetailsReturnsBadRequestTest()
		{
			_supermarketsServiceMock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
				.Throws(new Exception());

			var result = _supermarketsController.Details(1).Result;
			Assert.AreEqual(typeof(BadRequestResult), result.GetType());
		}

		[Test]
		public void CreatePostRedirectToActionTest()
		{
			var result = _supermarketsController.Create(new Supermarket()).Result;

			Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
		}

		[Test]
		public void CreatePostReturnsViewTest()
		{
			var result = _supermarketsController.Create(null).Result;

			//Does not returns view result if model is invalid. Validation problems.
			Assert.AreEqual(typeof(ViewResult), result.GetType());
		}

		[Test]
		public void EditReturnsBadRequestTest()
		{
			_supermarketsServiceMock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
				.Throws(new Exception());
			var result = _supermarketsController.Edit(1).Result;
			Assert.AreEqual(typeof(BadRequestResult), result.GetType());
		}

		[Test]
		public void EditReturnsViewTest()
		{
			_supermarketsServiceMock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
				.ReturnsAsync(new Supermarket());

			var result = _supermarketsController.Edit(1).Result;
			Assert.AreEqual(typeof(ViewResult), result.GetType());
		}

		[Test]
		public void EditPostReturnsBadRequestTest()
		{
			_supermarketsServiceMock.Setup(m => m.EditAsync(It.IsAny<Supermarket>()))
				.Throws(new Exception());
			var result = _supermarketsController.Edit(1, new Supermarket()
			{
				Id = 1,
			}).Result;

			Assert.AreEqual(typeof(BadRequestResult), result.GetType());
		}

		[Test]
		public void EditPostReturnsRedirectToActionResultTest()
		{
			var result = _supermarketsController.Edit(1, new Supermarket()
			{
				Id = 1,
			}).Result;

			Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
		}

		[Test]
		public void DeleteReturnsViewTest()
		{
			_supermarketsServiceMock.Setup(m => m.DeleteAsync(It.IsAny<int>()))
				.Throws(new Exception());

			var result = _supermarketsController.Delete(1).Result;
			Assert.AreEqual(typeof(ViewResult), result.GetType());
		}

		[Test]
		public void DeleteReturnsRedirectToAction()
		{
			_supermarketsServiceMock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
				.ReturnsAsync(new Supermarket() { Id = 1 });

			var result = _supermarketsController.Delete(1).Result;
			Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
		}

		[Test]
		public void DeleteConfirmedReturnsRedirectToAction()
		{
			var result = _supermarketsController.DeleteConfirmed(1).Result;
			Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
		}
	}
}
