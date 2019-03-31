using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CityInfoRestApi;
using CityInfoRestApi.Controllers;
using CityInfoRestApi.Models;
using Moq;
using CityInfoRestApi.Repositories;
using System.Net;

namespace CityInfoRestApi.Tests.Controllers
{

	[TestClass]
	public class CityInfoControllerTest
	{

		//[TestMethod]
		//public void GetReturnsNotFound()
		//{
		//	// Arrange
		//	var mockRepository = new Mock<ICityInfoRepository>();
		//	var controller = new CityInfoController(mockRepository.Object);

		//	// Act
		//	var actionResult = controller.GetCities();

		//	// Assert
		//	Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));

		//}


		[TestMethod]
		public void Get_NotNullReturns()
		{
			var mockRepository = new Mock<ICityInfoRepository>();
			var controller = new CityInfoController(mockRepository.Object);			
			var actionResult = controller.Get("abc");
			Assert.IsNotNull(actionResult);
		}


		[TestMethod]
		public void Delete_Test()
		{
			var mockRepository = new Mock<ICityInfoRepository>();
			var controller = new CityInfoController(mockRepository.Object);
			var actionResult = controller.Delete(Guid.NewGuid());
			Assert.IsNotNull(actionResult);
		
		}

		//	[TestMethod]
		//	public void Get()
		//	{
		//		// Arrange
		//		CityInfoController controller = new CityInfoController();

		//		// Act
		//		IEnumerable<string> result = controller.Get();

		//		// Assert
		//		Assert.IsNotNull(result);
		//		Assert.AreEqual(2, result.Count());
		//		Assert.AreEqual("value1", result.ElementAt(0));
		//		Assert.AreEqual("value2", result.ElementAt(1));
		//	}

		//	[TestMethod]
		//	public void GetById()
		//	{
		//		// Arrange
		//		CityInfoController controller = new CityInfoController();

		//		// Act
		//		string result = controller.Get(5);

		//		// Assert
		//		Assert.AreEqual("value", result);
		//	}

		//	[TestMethod]
		//	public void Post()
		//	{
		//		// Arrange
		//		CityInfoController controller = new CityInfoController();

		//		// Act
		//		controller.Post("value");

		//		// Assert
		//	}

		//	[TestMethod]
		//	public void Put()
		//	{
		//		// Arrange
		//		CityInfoController controller = new CityInfoController();

		//		// Act
		//		controller.Put(5, "value");

		//		// Assert
		//	}

		//	[TestMethod]
		//	public void Delete()
		//	{
		//		// Arrange
		//		CityInfoController controller = new CityInfoController();

		//		// Act
		//		controller.Delete(5);

		//		// Assert
		//	}
	}
	}

