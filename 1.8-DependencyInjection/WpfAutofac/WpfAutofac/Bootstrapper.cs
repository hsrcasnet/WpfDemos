using System.Reflection;
using Autofac;
using WpfAutofac.Services;
using WpfAutofac.ViewModels;
using WpfAutofac.Views;

namespace WpfAutofac
{
    public static class Bootstrapper
    {
        private static IContainer container;

        public static IView RootView
        {
            get
            {
                if (container == null)
                {
                    Start();
                }

                return container.Resolve<IView>();
            }
        }
        public static IViewModel RootViewModel
        {
            get
            {
                if (container == null)
                {
                    Start();
                }

                return container.Resolve<IMainViewModel>();
            }
        }

        public static void Start()
        {
            if (container != null)
            {
                return;
            }

            // Create DI container builder
            var builder = new ContainerBuilder();
            
            // Register services, views, viewmodels
            var assemblies = new[] { Assembly.GetExecutingAssembly() };

            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(IService).IsAssignableFrom(t))
                .SingleInstance()
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(IView).IsAssignableFrom(t))
                .AsImplementedInterfaces()
                .AsSelf();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(IViewModel).IsAssignableFrom(t))
                .AsImplementedInterfaces()
                .AsSelf();

            // Finally, build the DI container
            container = builder.Build();
        }

        public static void Stop()
        {
            container.Dispose();
        }
    }
}