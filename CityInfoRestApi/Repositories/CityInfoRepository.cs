using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfoRestApi.EntityFramework;
using CityInfoRestApi.Models;
using Microsoft.Practices.Unity;

namespace CityInfoRestApi.Repositories
{
	public class CityInfoRepository : ICityInfoRepository
	{
		[Dependency]
		public CityInfoDatabaseEntities databaseEntities { get; set; }

		public void AddCity(CityInfoModel cityInfoModel)
		{
			var cityInfo = new City
			{
				Id = cityInfoModel.Id,
				Name = cityInfoModel.Name,
				State = cityInfoModel.State,
				Country = cityInfoModel.Country,
				TouristRating = cityInfoModel.TouristRating,
				DateEstablished = cityInfoModel.DateEstablished,
				EstimatedPopulation = cityInfoModel.EstimatedPopulation
			};

			databaseEntities.Cities.Add(cityInfo);
			databaseEntities.SaveChanges();
		}

		public void DeleteCity(Guid Id)
		{
			var cityInfo = databaseEntities.Cities.Where(m => m.Id == Id).FirstOrDefault();
			databaseEntities.Cities.Remove(cityInfo);
			databaseEntities.SaveChanges();
		}

		public IEnumerable<CityInfoModel> GetCities()
		{
			var cities = new List<CityInfoModel>();
			var cityInfoDetails = databaseEntities.Cities;
			if (cityInfoDetails != null)
			{
				Parallel.ForEach(cityInfoDetails, x =>
				{
					var cityInfoModel = new CityInfoModel();
					cityInfoModel.Id = x.Id;
					cityInfoModel.Name = x.Name;
					cityInfoModel.State = x.State;
					cityInfoModel.Country = x.Country;
					cityInfoModel.TouristRating = x.TouristRating;
					cityInfoModel.DateEstablished = x.DateEstablished;
					cityInfoModel.EstimatedPopulation = x.EstimatedPopulation;
					cities.Add(cityInfoModel);
				});
				return cities;
			}
			return cities;
		}

		public CityInfoModel GetCity(Guid Id)
		{
			var cityInfo = databaseEntities.Cities.Where(m => m.Id == Id).FirstOrDefault();
			CityInfoModel cityInfoModel = null;
			if (cityInfo != null)
			{
				cityInfoModel = new CityInfoModel
				{
					Id = cityInfo.Id,
					Name = cityInfo.Name,
					State = cityInfo.State,
					Country = cityInfo.Country,
					TouristRating = cityInfo.TouristRating,
					DateEstablished = cityInfo.DateEstablished,
					EstimatedPopulation = cityInfo.EstimatedPopulation
				};
				return cityInfoModel;
			}
			return cityInfoModel;
		}

		public void UpdateCity(CityInfoModel cityInfoModel)
		{
			var cityInfo = databaseEntities.Cities.Where(m => m.Id == cityInfoModel.Id).FirstOrDefault();
			if (cityInfo != null)
			{
				cityInfo.TouristRating = cityInfoModel.TouristRating;
				cityInfo.DateEstablished = cityInfoModel.DateEstablished;
				cityInfo.EstimatedPopulation = cityInfoModel.EstimatedPopulation;
				databaseEntities.SaveChanges();
			}
		}
	}
}