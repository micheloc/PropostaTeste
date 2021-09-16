using FluentValidation.WebApi;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "api",
                routeTemplate: "api/{controller}/{objID}",
                defaults: new { objID = RouteParameter.Optional }
            );
        }
    }
}
