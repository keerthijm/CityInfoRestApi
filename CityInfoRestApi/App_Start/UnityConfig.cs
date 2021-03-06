using CityInfoRestApi.Repositories;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace CityInfoRestApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

			// register all your components with the container here
			// it is NOT necessary to register your controllers

			// e.g. container.RegisterType<ITestService, TestService>();
			container.RegisterType<ICityInfoRepository, CityInfoRepository>();
			GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}