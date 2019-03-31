﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityInfoRestApi.Models
{
	public class Coord
	{
		public double lon { get; set; }
		public double lat { get; set; }
	}

	public class Weather
	{
		public int id { get; set; }
		public string main { get; set; }
		public string description { get; set; }
		public string icon { get; set; }
	}

	public class Main
	{
		public double temp { get; set; }
		public int pressure { get; set; }
		public int humidity { get; set; }
		public int temp_min { get; set; }
		public int temp_max { get; set; }
	}

	public class Wind
	{
		public double speed { get; set; }
		public int deg { get; set; }
	}

	public class Clouds
	{
		public int all { get; set; }
	}

	public class Sys
	{
		public int type { get; set; }
		public int id { get; set; }
		public double message { get; set; }
		public string country { get; set; }
		public int sunrise { get; set; }
		public int sunset { get; set; }
	}

	public class ResponseWeather
	{
		public Coord coord { get; set; }
		public List<Weather> weather { get; set; }
		public string @base { get; set; }
		public Main main { get; set; }
		public int visibility { get; set; }
		public Wind wind { get; set; }
		public Clouds clouds { get; set; }
		public int dt { get; set; }
		public Sys sys { get; set; }
		public int id { get; set; }
		public string name { get; set; }
		public int cod { get; set; }
	}

	public class Country
	{
		public string Name { get; set; }
		public string[] TopLevelDomain { get; set; }
		public string Alpha2Code { get; set; }
		public string Alpha3Code { get; set; }
		public string[] CallingCodes { get; set; }
		public string Capital { get; set; }
		public string[] AltSpellings { get; set; }
		public string Region { get; set; }
		public string Subregion { get; set; }
		public int Population { get; set; }
		public float[] Latlng { get; set; }
		public string Demonym { get; set; }
		public float Area { get; set; }
		public float Gini { get; set; }
		public string[] Timezones { get; set; }
		public string[] Borders { get; set; }
		public string NativeName { get; set; }
		public string NumericCode { get; set; }
		public Currency[] Currencies { get; set; }
		public Language[] Languages { get; set; }
		public Translations Translations { get; set; }
		public string Flag { get; set; }
		public Regionalbloc[] RegionalBlocs { get; set; }
		public string Cioc { get; set; }
	}

	public class Translations
	{
		public string De { get; set; }
		public string Es { get; set; }
		public string Fr { get; set; }
		public string Ja { get; set; }
		public string It { get; set; }
		public string Br { get; set; }
		public string Pt { get; set; }
		public string Nl { get; set; }
		public string Hr { get; set; }
		public string Fa { get; set; }
	}

	public class Currency
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public string Symbol { get; set; }
	}

	public class Language
	{
		public string Iso639_1 { get; set; }
		public string Iso639_2 { get; set; }
		public string Name { get; set; }
		public string NativeName { get; set; }
	}

	public class Regionalbloc
	{
		public string Acronym { get; set; }
		public string Name { get; set; }
		public object[] OtherAcronyms { get; set; }
		public object[] OtherNames { get; set; }
	}
}