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
		}


		[TestMethod]
		public void AddCityTestMethod()
		{
			// Arrange
			var newGuid = Guid.NewGuid();
			var mockcity = new CityInfoModel {Id = newGuid, Name = "mock city 1"};
			iCityInfoRepository.Setup(repo => repo.AddCity(mockcity));

			var cityInfoBaseModel = new CityInfoBaseModel
			{
				Name = "test1",
				Country = "United Kingdom",
				TouristRating = 2,
				EstimatedPopulation = 1234
			};
			var actionResult = controller.Post(cityInfoBaseModel);
			Assert.IsNotNull(actionResult);
		}


		[TestMethod]
		public void WhenPuttingACityItShouldBeUpdated()
		{
			// Arrange
			var newGuid = Guid.NewGuid();
			var mockcity = new CityInfoModel {Id = newGuid, Name = "mock city 1"};
			iCityInfoRepository.Setup(repo => repo.AddCity(mockcity));

			var cityInfoUpdateModel = new CityInfoUpdateModel {Id = newGuid, TouristRating = 2, EstimatedPopulation = 1234};
			var actionResult = controller.Put(cityInfoUpdateModel).Result;
			// Act

			var response = actionResult as OkNegotiatedContentResult<CityInfoModel>;

			Assert.IsNotNull(response);
			var city = response.Content;

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
	}
}