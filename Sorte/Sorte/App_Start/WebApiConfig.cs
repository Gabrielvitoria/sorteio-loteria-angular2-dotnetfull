using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Sorte.Business.Services;
using Sorte.Domain.ContextMega.Contracts.Services;
using Sorte.Domain.ContextMega.Repositories;
using Sorte.Helpers;
using Sorte.Infraestructure.Contexs.MegaSenha.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace Sorte
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services           

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors();

            GlobalConfiguration.Configuration.Formatters.
        JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
