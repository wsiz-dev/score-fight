using Autofac;
using ScoreFight.Domain;

namespace ScoreFight.Infrastructure
{
    public class Startup
    {
        public static void Configure(ContainerBuilder containerBuilder)
        {
            ConfigureMediator(containerBuilder);
            containerBuilder.RegisterType<FootballRepository>().As<IFootballRepository>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<EfContext>().AsSelf().InstancePerLifetimeScope();
        }

        private static void ConfigureMediator(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

            containerBuilder
                .Register(factory =>
                {
                    var lifetimeScope = factory.Resolve<ILifetimeScope>();
                    return new AutofacDependencyResolver(lifetimeScope.BeginLifetimeScope());
                })
                .As<IDependencyResolver>()
                .InstancePerLifetimeScope();

            var handlersAssembly = typeof(IMediator).Assembly;

            containerBuilder
                .RegisterAssemblyTypes(handlersAssembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            containerBuilder
                .RegisterAssemblyTypes(handlersAssembly)
                .AsClosedTypesOf(typeof(IQueryHandler<,>))
                .InstancePerLifetimeScope();
        }
    }
}
