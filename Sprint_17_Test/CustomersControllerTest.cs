using NUnit.Framework;
using Sprint_17.Controllers;
using Sprint_17.Services;
using Moq;
using Sprint_17.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Sprint_17.Test
{
	public class CustomerControllerTests
	{
		Mock<ICustomers> _customerServiceMock;
		CustomersController _customersController;

		[SetUp]
		public void SetUp()
		{
			_customerServiceMock = new Mock<ICustomers>();
			_customersController = new CustomersController(_customerServiceMock.Object);
		}

		[Test]
		public void DetailsReturnsViewTest()
		{
			int cusId = 1;
			Customer cus = new Customer()
			{
				Id = cusId
			};

			_customerServiceMock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
				.ReturnsAsync(cus);

			var result = _customersController.Details(1).Result;
			Assert.AreEqual(typeof(ViewResult), result.GetType());	
		}

		[Test]
		public void DetailsReturnsBadRequestTest()
		{
			_customerServiceMock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
				.Throws(new Exception());

			var result = _customersController.Details(1).Result;
			Assert.AreEqual(typeof(BadRequestResult), result.GetType());
		}

		[Test]
		public void CreatePostRedirectToActionTest()
		{	
			//Gives true with an empty object?
			var result = _customersController.Create(new Customer()).Result;

			Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
		}

		[Test]
		public void CreatePostReturnsViewTest()
		{
			var result = _customersController.Create(null).Result;

			//Does not returns view result if model is invalid. Validation problems.
			Assert.AreEqual(typeof(ViewResult), result.GetType());
		}

		[Test]
		public void EditReturnsNotFoundTest()
		{
			_customerServiceMock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
				.ReturnsAsync(() => null);
			var result = _customersController.Edit(1).Result;
			Assert.AreEqual(typeof(NotFoundResult), result.GetType());
		}

		[Test]
		public void EditReturnsViewTest()
		{
			_customerServiceMock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
				.ReturnsAsync(new Customer());

			var result = _customersController.Edit(1).Result;
			Assert.AreEqual(typeof(ViewResult), result.GetType());
		}

		[Test]
		public void EditPostReturnsNotFoundTest()
		{
			var result = _customersController.Edit(1, new Customer() { Id = 2 }).Result;
			Assert.AreEqual(typeof(NotFoundResult), result.GetType());
		}

		[Test]
		public void EditPostReturnsViewTest()
		{
			var result = _customersController.Edit(1, new Customer() { Id = 1 }).Result;
			//Another validation problem
			Assert.AreEqual(typeof(ViewResult), result.GetType());
		}

		[Test]
		public void EditPostReturnsBadRequestTest()
		{
			_customerServiceMock.Setup(m => m.EditAsync(It.IsAny<Customer>()))
				.Throws(new DbUpdateConcurrencyException());
			var result = _customersController.Edit(1, new Customer()
			{
				Id = 1,
				Address = "Lviv",
				Discount = "O",
				FirstName = "Andrii",
				LastName = "Stehura"
			}).Result;

			Assert.AreEqual(typeof(BadRequestResult), result.GetType());
		}

		[Test]
		public void EditPostReturnsRedirectToActionResultTest()
		{
			_customerServiceMock.Setup(m => m.EditAsync(It.IsAny<Customer>()))
				.Throws(new DbUpdateConcurrencyException());
			var result = _customersController.Edit(1, new Customer()
			{
				Id = 1,
				Address = "Lviv",
				Discount = "O",
				FirstName = "Andrii",
				LastName = "Stehura"
			}).Result;

			Assert.AreEqual(typeof(BadRequestResult), result.GetType());
		}

		[Test]
		public void DeleteReturnsViewTest()
		{
			_customerServiceMock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
				.ReturnsAsync(new Customer());

			var result = _customersController.Delete(1).Result;
			Assert.AreEqual(typeof(ViewResult), result.GetType());
		}

		[Test]
		public void DeleteReturnsNotFoundResult()
		{
			_customerServiceMock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
				.ReturnsAsync(() => null);

			var result = _customersController.Delete(1).Result;
			Assert.AreEqual(typeof(NotFoundResult), result.GetType());
		}

		[Test]
		public void DeleteConfirmedViewResultTest()
		{
			_customerServiceMock.Setup(m => m.DeleteAsync(It.IsAny<int>()))
				.Throws(new Exception());

			var result = _customersController.DeleteConfirmed(1).Result;
			Assert.AreEqual(typeof(ViewResult), result.GetType());
		}

		[Test]
		public void DeleteConfirmedRedirectToActionTest()
		{
			var result = _customersController.DeleteConfirmed(1).Result;
			Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());
		}
	}
}