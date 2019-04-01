using System;

namespace CityInfoRestApi.Models
{
	public class CityInfoBaseModel : CityInfoOtherModel
	{
		public string Name { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
	}


	public class CityInfoOtherModel
	{
		public byte? TouristRating { get; set; }
		public DateTime? DateEstablished { get; set; }
		public long? EstimatedPopulation { get; set; }
	}

	public class CityInfoUpdateModel : CityInfoOtherModel
	{
		public Guid Id { get; set; }
	}

	public class CityInfoModel : CityInfoBaseModel
	{
		public Guid Id { get; set; }
	}

	public class CityWithExtraInfoModel : CityInfoModel
	{
		//2 digit country code, 
		//3 digit country code, 
		//currency code
		//weather for the city
		public string TwoDigitCountryCode { get; set; }

		public string ThreeDigitCountryCode { get; set; }

		public string CurrencyCode { get; set; }

		public string WeatherInfo { get; set; }
	}
}