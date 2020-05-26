using System.Web.Http;

namespace MyFirstApi.Configuration
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Attribute routing.
            config.MapHttpAttributeRoutes();

            // Convention-based routing.
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "GetValues",
            //    routeTemplate: "api/{controller}/{identifier}",
            //    defaults: new { controller="Values", identifier = RouteParameter.Optional }
            //);
        }
    }
}