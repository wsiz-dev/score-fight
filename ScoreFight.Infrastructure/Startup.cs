using Autofac;
using ScoreFight.Domain;
using ScoreFight.Domain.Bets;
using ScoreFight.Domain.Bets.Validators;
using ScoreFight.Domain.Matches;
using ScoreFight.Domain.Players;

namespace ScoreFight.Infrastructure
{
    public class Startup
    {
        public static void Configure(ContainerBuilder containerBuilder)
        {
            ConfigureMediator(containerBuilder);
            containerBuilder.RegisterType<FootballRepository>().As<IFootballRepository>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<MatchesRepository>().As<IMatchesRepository>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<PlayersRepository>().As<IPlayersRepository>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<BetCommandValidator>().As<BetCommandValidator>().InstancePerLifetimeScope();
            containerBuilder.RegisterType<BetRepository>().As<IBetRepository>().InstancePerLifetimeScope();
            containerBuilder.Register(context =>
            {
                var efContext = new EfContext();
                efContext.Database.EnsureCreated();
                return efContext;
            }).InstancePerLifetimeScope();
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
