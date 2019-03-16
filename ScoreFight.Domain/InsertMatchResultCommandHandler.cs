using System;

namespace ScoreFight.Domain
{
    internal class InsertMatchResultCommandHandler : ICommandHandler<InsertMatchResultCommand>
    {
        private readonly IFootballRepository _repository;

        public InsertMatchResultCommandHandler(IFootballRepository repository)
        {
            _repository = repository;
        }

        public void Handle(InsertMatchResultCommand command)
        {
            var homeTeam = _repository.GetTeam(command.HomeTeamName);
            if (homeTeam == null)
            {
                throw new NullReferenceException($"Given team '{command.HomeTeamName}' does not exists.");
            }

            var awayTeam = _repository.GetTeam(command.AwayTeamName);
            if (awayTeam == null)
            {
                throw new NullReferenceException($"Given team '{command.AwayTeamName}' does not exists.");
            }

            var matchResult = new MatchResult(homeTeam, command.HomeTeamGoals, awayTeam, command.AwayTeamGoals);
            matchResult.ApplyResult(homeTeam, awayTeam);

            _repository.Save(matchResult);
        }
    }
}
