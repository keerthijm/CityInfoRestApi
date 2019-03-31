using CityInfoRestApi.Models;
using CityInfoRestApi.Repositories;
using Newtonsoft.Json;
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

		private string countriesUrl = "https://restcountries.eu/rest/v2/name/";
		string apiKey = "e0e0db2d215e486f923f5af3c9950ba9";

		
		
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
				return Request.CreateResponse(HttpStatusCode.OK, result, "City Saved Successfully.");
			}
			else
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, result, "City Not Saved, Please try again.");
			}
		}


		[HttpGet]
		public async Task<HttpResponseMessage> GetCities()
		{
			var cities = iCityInfo.GetCities();
			return Request.CreateResponse(HttpStatusCode.OK, cities);
		}

		[HttpGet]
		public async Task<HttpResponseMessage> Get(string Name)
		{
			Name = Name.Replace('"', ' ').Trim();
			Name = Name.Replace("\"", string.Empty).Trim();
			var cities = iCityInfo.GetCities().Where(t=>t.Name.ToLower().Equals(Name.ToLower())).ToList();

			List<CityWithExtraInfoModel> cityWithExtraInfos = new List<CityWithExtraInfoModel>();
			foreach (var city in cities)
			{
				CityWithExtraInfoModel cityWithExtraInfoModel = new CityWithExtraInfoModel
				{
					Id = city.Id,
					Name = city.Name,
					State = city.State,
					Country = city.Country,
					TouristRating = city.TouristRating,
					DateEstablished = city.DateEstablished,
					EstimatedPopulation = city.EstimatedPopulation
				};

				var countryInfoResult = HttpClientHelper.RequestHttpClient(countriesUrl, city.Country).Content.ReadAsStringAsync().Result;				
				var countryInfoJson = JsonConvert.DeserializeObject<List<Country>>(countryInfoResult);

				cityWithExtraInfoModel.TwoDigitCountryCode = countryInfoJson[0].Alpha2Code;
				cityWithExtraInfoModel.ThreeDigitCountryCode = countryInfoJson[0].Alpha3Code;
				cityWithExtraInfoModel.CurrencyCode = countryInfoJson[0].Currencies[0].Symbol;
				var weatherInfoResult = HttpClientHelper.RequestHttpClient("http://api.openweathermap.org/data/2.5/weather?q=" + city.Name + "&appid=" + apiKey).Content.ReadAsStringAsync().Result;
				var responseWeather = JsonConvert.DeserializeObject<ResponseWeather>(weatherInfoResult);			
				
				cityWithExtraInfoModel.WeatherInfo = responseWeather.weather[0].description;

				cityWithExtraInfos.Add(cityWithExtraInfoModel);
			}


			return Request.CreateResponse(HttpStatusCode.OK, cityWithExtraInfos);
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
		public async Task<HttpResponseMessage> Put(CityInfoUpdateModel cityInfoUpdateModel)
		{
			CityInfoModel cityInfoModel = new CityInfoModel();
			cityInfoModel.Id = cityInfoUpdateModel.Id;		
			cityInfoModel.TouristRating = (byte)cityInfoUpdateModel.TouristRating;
			cityInfoModel.DateEstablished = cityInfoUpdateModel.DateEstablished;
			cityInfoModel.EstimatedPopulation = cityInfoUpdateModel.EstimatedPopulation;
			iCityInfo.UpdateCity(cityInfoModel);

			var city = iCityInfo.GetCity(cityInfoUpdateModel.Id);

			if (city != null)
			{
				return Request.CreateResponse(HttpStatusCode.OK, city, "City Updated Successfully.");
			}
			else
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, city, "City Not Updated, Please try again.");
			}
		}


	
	}
}
