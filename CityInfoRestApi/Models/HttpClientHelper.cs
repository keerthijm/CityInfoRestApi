﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CityInfoRestApi.Models
{
	public class HttpClientHelper
	{
		public static HttpResponseMessage RequestHttpClient(string url, string urlParameters)
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri(url);

			// Add an Accept header for JSON format.
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));

			// List data response.
			var response =
				client.GetAsync(urlParameters)
					.Result; // Blocking call! Program will wait here until a response is received or a timeout occurs.
			client.Dispose();
			if (response.IsSuccessStatusCode)
				return response;
			return null;

			//Make any other calls using HttpClient here.

			//Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
		}


		public static HttpResponseMessage RequestHttpClient(string url)
		{
			var client = new HttpClient();

			// Add an Accept header for JSON format.
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));

			// List data response.
			var response =
				client.GetAsync(url)
					.Result; // Blocking call! Program will wait here until a response is received or a timeout occurs.
			client.Dispose();
			if (response.IsSuccessStatusCode)
				return response;
			return null;

			//Make any other calls using HttpClient here.

			//Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
		}
	}
}