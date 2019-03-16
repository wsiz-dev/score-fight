using Autofac;
using ScoreFight.Domain;

namespace ScoreFight.Infrastructure
{
    internal class AutofacDependencyResolver : IDependencyResolver
    {
        private readonly ILifetimeScope _lifetimeScope;

        public AutofacDependencyResolver(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public T ResolveOrDefault<T>() where T : class
            => _lifetimeScope.ResolveOptional<T>();
    }
}
