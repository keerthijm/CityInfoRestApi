using CityInfoRestApi.EntityFramework;
using CityInfoRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
