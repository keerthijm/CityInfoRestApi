using CityInfoRestApi.Models;
using CityInfoRestApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CityInfoRestApi.Controllers
{
	[RoutePrefix("api/CityInfo")]
	public class CityInfoController : ApiController
	{
		
		private readonly ICityInfoRepository iCityInfo;
		public CityInfoController(ICityInfoRepository _iCityInfo)
		{
			iCityInfo = _iCityInfo;
		}
		
		[HttpPost]
		public async Task<HttpResponseMessage> Post(CityInfoBaseModel cityInfoBaseModel)
		{
			CityInfoModel cityInfoModel = new CityInfoModel();
			cityInfoModel.Id = Guid.NewGuid();
			cityInfoModel.Name = cityInfoBaseModel.Name;
			cityInfoModel.State = cityInfoBaseModel.State;
			cityInfoModel.Country = cityInfoBaseModel.Country;
			cityInfoModel.TouristRating = cityInfoBaseModel.TouristRating;
			cityInfoModel.DateEstablished = cityInfoBaseModel.DateEstablished;
			cityInfoModel.EstimatedPopulation = cityInfoBaseModel.EstimatedPopulation;
			iCityInfo.AddCity(cityInfoModel);			

			var result = iCityInfo.GetCity(cityInfoModel.Id);

			if (result != null)
			{
				return Request.CreateResponse(HttpStatusCode.OK, "City Saved Successfully.");
			}
			else
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, "City Not Saved, Please try again.");
			}
		}


		[HttpGet]
		public async Task<HttpResponseMessage> GetCities()
		{
			var details = iCityInfo.GetCities();
			return Request.CreateResponse(HttpStatusCode.OK, details);
		}

		[HttpDelete]
		// DELETE api/CityInfo/Id
		public async Task<HttpResponseMessage> Delete(Guid id)
		{
			iCityInfo.DeleteCity(id);
			var city = iCityInfo.GetCity(id);

			if (city == null)
			{
				return Request.CreateResponse(HttpStatusCode.OK, "City Deleted Successfully.");
			}
			else
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, "City Not Deleted, Please try again.");
			}

		}

		// PUT api/CityInfo/Id
		[HttpPut]

		public async Task<HttpResponseMessage> Put(Guid id, [FromBody]int TouristRating, [FromBody]DateTime DateEstablished, [FromBody]long EstimatedPopulation)
		{
			CityInfoModel cityInfoModel = new CityInfoModel();
			cityInfoModel.Id = id;		
			cityInfoModel.TouristRating = (byte)TouristRating;
			cityInfoModel.DateEstablished = DateEstablished;
			cityInfoModel.EstimatedPopulation = EstimatedPopulation;
			iCityInfo.UpdateCity(cityInfoModel);

			var city = iCityInfo.GetCity(id);

			if (city != null)
			{
				return Request.CreateResponse(HttpStatusCode.OK, "City Updated Successfully.");
			}
			else
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, "City Not Updated, Please try again.");
			}
		}

	}
}
