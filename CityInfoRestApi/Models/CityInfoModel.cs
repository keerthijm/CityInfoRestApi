using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityInfoRestApi.Models
{
	public class CityInfoBaseModel
	{		
		public string Name { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
		public byte? TouristRating { get; set; }
		public DateTime? DateEstablished { get; set; }
		public long? EstimatedPopulation { get; set; }
	}

	public class CityInfoModel: CityInfoBaseModel
	{
		public Guid Id { get; set; }	
	}
}
