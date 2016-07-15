using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using Domain.Interfaces;
using Repository;
using SimpleInjector.Extensions.ExecutionContextScoping;

[assembly: OwinStartup(typeof(RestSelfHost.Startup))]

namespace RestSelfHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            HttpConfiguration config = new HttpConfiguration();

            config.EnableCors();
            config.Routes.MapHttpRoute(
                name: "RestSelfHost",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            container.Register<IInvoiceRepository, InvoiceRepository>(Lifestyle.Scoped);
            container.Verify();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            app.Use(async (context, next) =>
            {
                using (container.BeginExecutionContextScope())
                {
                    await next();
                }
            });

            app.UseWebApi(config);

        }
    }
}
