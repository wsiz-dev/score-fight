using System;
using ScoreFight.Domain.Bets.Validators;
using ScoreFight.Domain.Matches;

namespace ScoreFight.Domain.Bets.Commands
{
    internal class SetBetCommandHandler : ICommandHandler<SetBetCommand>
    {
        private readonly IBetRepository _betRepository;
        private readonly IMatchesRepository _matchesRepository;
        private readonly BetCommandValidator _betCommandValidator;

        public SetBetCommandHandler(IBetRepository betRepository, IMatchesRepository matchesRepository, BetCommandValidator betCommandValidator)
        {
            _betRepository = betRepository;
            _matchesRepository = matchesRepository;
            _betCommandValidator = betCommandValidator;
        }

        public void Handle(SetBetCommand command)
        {
            var playerId = Guid.Parse(command.PlayerId);
            var matchId = Guid.Parse(command.MatchId);

            _betCommandValidator.CheckIfBetAlreadyExist(playerId, matchId);

            var match = _matchesRepository.GetById(matchId);

            _betCommandValidator.CheckIfMatchDoesNotExist(match, command.MatchId);
            _betCommandValidator.CheckIfMatchAlreadyStarted(match);

            var bet = new Bet(playerId, matchId, (MatchResults)command.TeamBet, command.PointsBet);
            bet.Player.CountPointsAfterBet(command.PointsBet);

            _betRepository.Save(bet);
        }

    }
}
