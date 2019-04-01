using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using CityInfoRestApi.Controllers;
using CityInfoRestApi.Models;
using CityInfoRestApi.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CityInfoRestApi.Tests.Controllers
{
	[TestClass]
	public class CityInfoControllerTest
	{
		private readonly CityInfoController controller;
		private readonly Mock<ICityInfoRepository> iCityInfoRepository;

		public CityInfoControllerTest()
		{
			iCityInfoRepository = new Mock<ICityInfoRepository>();
			controller = new CityInfoController(iCityInfoRepository.Object);
		}


		[TestMethod]
		public async Task IndexTest_ReturnsViewWithCitiesList()
		{
			// Arrange
			var mockcityList = new List<CityInfoModel>
			{
				new CityInfoModel {Name = "mock city 1"},
				new CityInfoModel {Name = "mock city 2"}
			};
			iCityInfoRepository.Setup(repo => repo.GetCities()).Returns(mockcityList);

			// Act
			var result = controller.GetCities().Result;
			var response = result as OkNegotiatedContentResult<IEnumerable<CityInfoModel>>;
			Assert.IsNotNull(response);
			var cities = response.Content;
			Assert.AreEqual(2, cities.Count());

			// Assert
		}


		[TestMethod]
		public void WhenPuttingACityItShouldBeUpdated()
		{
			// Arrange
			var id = Guid.Parse("648038fb-260d-4a84-89e1-0057b151a4bd");
			var cityInfoUpdateModel = new CityInfoUpdateModel {Id = id, TouristRating = 2, EstimatedPopulation = 1234};
			var actionResult = controller.Put(cityInfoUpdateModel).Result;
			// Act

			var response = actionResult as OkNegotiatedContentResult<CityInfoModel>;

			Assert.IsNotNull(response);
			var city = response.Content;

			Assert.AreEqual(id, city.Id);
			Assert.AreEqual(2, city.TouristRating);
		}


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
		//		IEnumerable<string> result = controller.Get();

		//		// Act
		//		CityInfoController controller = new CityInfoController();
		//		// Arrange
		//	{
		//	public void Get()

		//	[TestMethod]

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