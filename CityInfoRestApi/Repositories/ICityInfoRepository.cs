using System;
using System.Collections.Generic;
using CityInfoRestApi.Models;

namespace CityInfoRestApi.Repositories
{
	public interface ICityInfoRepository
	{
		IEnumerable<CityInfoModel> GetCities();
		CityInfoModel GetCity(Guid Id);
		void AddCity(CityInfoModel cityInfoModel);
		void UpdateCity(CityInfoModel cityInfoModel);
		void DeleteCity(Guid Id);
	}
}