using Autofac;
using Backend.Services;
using Backend.Services.Adapter;
using log4net;
using System;

namespace Backend
{
    class Program
    {
        //This is your app entry point
        static void Main(string[] args)
        {
            var container = ConfigureContainer();

            //Get your application menu class
            var application = container.Resolve<IApplicationService>();

            //Run your application
            application.Run();
        }

        //You should configure DI container (Autofac) or other DI Framework
        private static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            //Here you should register Interfaces with their referent classes
            builder.RegisterType<ApplicationService>().As<IApplicationService>();
            builder.RegisterType<MovieStarsApplicationService>().As<IMovieStarsApplicationService>();
            builder.RegisterType<AccountingApplicationService>().As<IAccountingApplicationService>();

            builder.RegisterType<MovieStarsAdapter>().As<IMovieStarsAdapter>();

            builder.Register(c => LogManager.GetLogger(typeof(Object))).As<ILog>();

            return builder.Build();
        }
    }
}
