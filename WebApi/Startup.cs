using Microsoft.AspNetCore.Cors;
using Microsoft.Owin;
using Owin;
using System;
using System.Web.Configuration;

namespace WebApi.App_Start
{
    public partial class Startup
    {


        public void Configuration(IAppBuilder app)
        {

            var appSettings = WebConfigurationManager.AppSettings;

            if (!string.IsNullOrWhiteSpace(appSettings["cors:Origins"]))
            {
            }

            ConfigureAuth(app);
        }
    }
}