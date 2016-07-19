using Domain.Interfaces;
using Microsoft.Owin;
using Owin;
using Repository;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using SimpleInjector.Integration.WebApi;
using System.Configuration;
using System.Web.Http;

[assembly: OwinStartup(typeof(RestSelfHost.Startup))]

namespace RestSelfHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            var connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

            HttpConfiguration config = new HttpConfiguration();

            config.EnableCors();
            config.Routes.MapHttpRoute(
                name: "RestSelfHost",
                routeTemplate: "api/{version}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            config.EnableQuerySupport();

            config.MessageHandlers.Add(new KeyValidatorHandler());

            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            container.RegisterSingleton<IInvoiceRepository>(new InvoiceRepository(connectionString));
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
