using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using Sorte.Startup;
using Sorte.WebApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;

namespace Sorte.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            // Configura injeção de dependencia
            var container = new UnityContainer();
            DependencyResolver.Resolve(container);

            config.DependencyResolver  = new UnityResolver(container);

            


            ConfigureWebApi(config);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
        public static void ConfigureWebApi(HttpConfiguration config)
        {
            // Remove xml
            var formattrs = config.Formatters;
            formattrs.Remove(formattrs.XmlFormatter);

            // Modifica identação resultado do json
            var jsonSettings = formattrs.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Modifica serialização
            //formattrs.JsonFormatter.SerializerSettings.PreserveReferencesHandling = new PreserveReferencesHandling.Objects;

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }
    }
}