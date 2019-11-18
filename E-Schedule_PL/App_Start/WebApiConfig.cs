using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace E_Schedule_PL
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // Web API configuration and services
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{apiToken}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
