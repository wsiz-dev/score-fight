using System;
using System.Linq;

namespace ScoreFight.Domain
{
    public class Mediator : IMediator
    {
        private readonly IDependencyResolver _dependencyResolver;

        public Mediator(IDependencyResolver dependencyResolver)
        {
            this._dependencyResolver = dependencyResolver;
        }

        public void Command<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _dependencyResolver.ResolveOrDefault<ICommandHandler<TCommand>>();
            if (handler == null)
            {
                throw new InvalidOperationException($"Command of type '{command.GetType()}' has not registered handler.");
            }

            handler.Handle(command);
        }

        public TResponse Query<TResponse>(IQuery<TResponse> query)
        {
            return (TResponse) GetType()
                .GetMethods()
                .First(x => x.Name == "Query" && x.GetGenericArguments().Length == 2)
                .MakeGenericMethod(query.GetType(), typeof(TResponse))
                .Invoke(this, new object[] {query});
        }

        public TResponse Query<TQuery, TResponse>(TQuery query) where TQuery : IQuery<TResponse>
        {
            var handler = _dependencyResolver.ResolveOrDefault<IQueryHandler<TQuery, TResponse>>();
            if (handler == null)
            {
                throw new InvalidOperationException($"Query of type '{query.GetType()}' has not registered handler.");
            }

            return handler.Handle(query);
        }
    }
}
