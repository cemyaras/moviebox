using Autofac;
using Autofac.Integration.Mvc;
using MovieBox.Business.Services;
using MovieBox.Data.Core;
using MovieBox.Ui.App_Start;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MovieBox.Ui
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<RottenTomatoService>().As<IRottenTomatoService>();
            builder.RegisterType<FetchService>().As<IFetchService>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

    }
}