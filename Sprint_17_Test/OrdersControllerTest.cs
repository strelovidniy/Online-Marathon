using NUnit.Framework;
using ShoppingSystem.Controllers;
using ShoppingSystem.Services;
using Moq;
using ShoppingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ShoppingSystem.Test
{
    public class OrdersControllerTests
    {
		Mock<IOrders> _ordersServiceMock;
		OrdersController _ordersController;

		[SetUp]
		public void SetUp()
		{
			_ordersServiceMock = new Mock<IOrders>();
			_ordersController = new OrdersController(_ordersServiceMock.Object);
		}

		[Test]
		public void DetailsReturnsViewTest()
		{
            _ordersServiceMock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
				.ReturnsAsync(new Order() {	Id = 1 });

			var result = _ordersController.Details(1).Result;
			Assert.AreEqual(typeof(ViewResult), result.GetType());
		}

		[Test]
		public void DetailsReturnsBadRequestTest()
		{
			_ordersServiceMock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
				.Throws(new Exception());

			var result = _ordersController.Details(1).Result;
			Assert.AreEqual(typeof(BadRequestResult), result.GetType());
		}

		[Test]
		public void CreatePostRedirectToActionTest()
		{
			var result = _ordersController.Create(new Order()).Result;

			Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
		}

		[Test]
		public void CreatePostReturnsViewTest()
		{
			_ordersServiceMock.Setup(m => m.AddAsync(It.IsAny<Order>()))
				.Throws(new Exception());

			var result = _ordersController.Create(new Order()).Result;

			Assert.AreEqual(typeof(ViewResult), result.GetType());
		}

		[Test]
		public void EditReturnsBadRequestTest()
		{
			_ordersServiceMock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
				.Throws(new Exception());
			var result = _ordersController.Edit(1).Result;
			Assert.AreEqual(typeof(BadRequestResult), result.GetType());
		}

		[Test]
		public void EditReturnsViewTest()
		{
			_ordersServiceMock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
				.ReturnsAsync(new Order());

			var result = _ordersController.Edit(1).Result;
			Assert.AreEqual(typeof(ViewResult), result.GetType());
		}

		[Test]
		public void EditPostReturnsBadRequestTest()
		{
			_ordersServiceMock.Setup(m => m.EditAsync(It.IsAny<Order>()))
				.Throws(new Exception());
			var result = _ordersController.Edit(1, new Order()
			{
				Id = 1,
			}).Result;

			Assert.AreEqual(typeof(BadRequestResult), result.GetType());
		}

		[Test]
		public void EditPostReturnsRedirectToActionResultTest()
		{
			var result = _ordersController.Edit(1, new Order()
			{
				Id = 1,
			}).Result;

			Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
		}

		[Test]
		public void DeleteReturnsViewTest()
		{
			_ordersServiceMock.Setup(m => m.DeleteAsync(It.IsAny<int>()))
				.Throws(new Exception());

			var result = _ordersController.Delete(1).Result;
			Assert.AreEqual(typeof(ViewResult), result.GetType());
		}

		[Test]
		public void DeleteReturnsRedirectToAction()
		{
			_ordersServiceMock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
				.ReturnsAsync(new Order() { Id = 1 });

			var result = _ordersController.Delete(1).Result;
			Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
		}

		[Test]
		public void DeleteConfirmedReturnsViewTest()
		{
			_ordersServiceMock.Setup(m => m.DeleteAsync(It.IsAny<int>()))
				.Throws(new Exception());

			var result = _ordersController.DeleteConfirmed(1).Result;
			Assert.AreEqual(typeof(ViewResult), result.GetType());
		}

		[Test]
		public void DeleteConfirmedReturnsRedirectToAction()
		{
			var result = _ordersController.DeleteConfirmed(1).Result;
			Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
		}
	}
}
