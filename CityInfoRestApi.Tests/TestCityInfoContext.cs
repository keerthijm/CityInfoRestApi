using CityInfoRestApi.EntityFramework;
using CityInfoRestApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfoRestApi.Tests
{
	public class TestCityInfoContext : CityInfoDatabaseEntities
	{
		private ICityInfoRepository iCityInfo;
		public TestCityInfoContext()
		{
			this.iCityInfo = new CityInfoRepository();
		}		
	}
}
