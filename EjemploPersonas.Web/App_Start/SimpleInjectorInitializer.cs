[assembly: WebActivator.PostApplicationStartMethod(typeof(EjemploPersonas.Web.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace EjemploPersonas.Web.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using EjemploPersonas.DAL;
    using EjemploPersonas.Models;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);

            container.Register<IRepository<Pais>, Repository<Pais>>(Lifestyle.Scoped);
            container.Register<IRepository<Departamento>, Repository<Departamento>>(Lifestyle.Scoped);
            container.Register<IRepository<Ciudad>, Repository<Ciudad>>(Lifestyle.Scoped);
            container.Register<IRepository<Cliente>, Repository<Cliente>>(Lifestyle.Scoped);
        }
    }
}