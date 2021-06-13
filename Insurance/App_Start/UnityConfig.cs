using Microsoft.AspNetCore.Hosting;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using Insurance.Interface;
using Unity;
using Unity.WebApi;

namespace Insurance
{
    public static class UnityConfig
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }


        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            container.RegisterType<IInsurance, TherapistRepositary>();
            //container.RegisterType<IAdmin, AdminRepository>();

            return container;
        }
    }
}