using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using ShoppingSystem.Controllers;
using ShoppingSystem.Models;
using ShoppingSystem.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Test
{
	class ProductsControllerTest
	{
		private Mock<IProducts> _productsServiceMock;
		private ProductsController _productsController;

		[SetUp]
		public void SetUp()
		{
			_productsServiceMock = new Mock<IProducts>();
			_productsController = new ProductsController(_productsServiceMock.Object);
		}

		[Test]
		public void DetailsReturnsViewTest()
		{
			int prodId = 1;
			Product prod = new Product()
			{
				Id = prodId
			};

			_productsServiceMock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
				.ReturnsAsync(prod);

			var result = _productsController.Details(1).Result;
			Assert.AreEqual(typeof(ViewResult), result.GetType());
		}

		[Test]
		public void DetailsReturnsBadRequestTest()
		{
			_productsServiceMock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
				.Throws(new Exception());

			var result = _productsController.Details(1).Result;
			Assert.AreEqual(typeof(BadRequestResult), result.GetType());
		}

		[Test]
		public void CreatePostRedirectToActionTest()
		{
			var result = _productsController.Create(new Product()).Result;

			Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
		}

		[Test]
		public void CreatePostReturnsViewTest()
		{
			_productsServiceMock.Setup(m => m.AddAsync(It.IsAny<Product>()))
				.Throws(new Exception());
			
			var result = _productsController.Create(new Product()).Result;

			Assert.AreEqual(typeof(ViewResult), result.GetType());
		}

		[Test]
		public void EditReturnsBadRequestTest()
		{
			_productsServiceMock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
				.Throws(new Exception());
			var result = _productsController.Edit(1).Result;
			Assert.AreEqual(typeof(BadRequestResult), result.GetType());
		}

		[Test]
		public void EditReturnsViewTest()
		{
			_productsServiceMock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
				.ReturnsAsync(new Product());

			var result = _productsController.Edit(1).Result;
			Assert.AreEqual(typeof(ViewResult), result.GetType());
		}

		[Test]
		public void EditPostReturnsBadRequestTest()
		{
			_productsServiceMock.Setup(m => m.EditAsync(It.IsAny<Product>()))
				.Throws(new Exception());
			var result = _productsController.Edit(1, new Product()
			{
				Id = 1,
				Name = "Onion",
				Price = 9
			}).Result;

			Assert.AreEqual(typeof(BadRequestResult), result.GetType());
		}

		[Test]
		public void EditPostReturnsRedirectToActionResultTest()
		{
			var result = _productsController.Edit(1, new Product()
			{
				Id = 1,
				Name = "Potato",
				Price = 12
			}).Result;

			Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
		}

		[Test]
		public void DeleteReturnsViewTest()
		{
			_productsServiceMock.Setup(m => m.DeleteAsync(It.IsAny<int>()))
				.Throws(new Exception());

			var result = _productsController.Delete(1).Result;
			Assert.AreEqual(typeof(ViewResult), result.GetType());
		}

		[Test]
		public void DeleteReturnsRedirectToActionResult()
		{
			var result = _productsController.Delete(1).Result;
			Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
		}

		[Test]
		public void DeleteConfirmedViewResultTest()
		{
			_productsServiceMock.Setup(m => m.DeleteAsync(It.IsAny<int>()))
				.Throws(new Exception());

			var result = _productsController.DeleteConfirmed(1).Result;
			Assert.AreEqual(typeof(ViewResult), result.GetType());
		}

		[Test]
		public void DeleteConfirmedRedirectToActionTest()
		{
			var result = _productsController.DeleteConfirmed(1).Result;
			Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
		}
	}
}
