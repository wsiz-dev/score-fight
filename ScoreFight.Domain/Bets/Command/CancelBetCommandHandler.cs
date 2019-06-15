using System;
using System.Collections.Generic;
using System.Text;
using ScoreFight.Domain.Bets.Validators;
using ScoreFight.Domain.Matches;
using ScoreFight.Domain.Players;

namespace ScoreFight.Domain.Bets.Command
{
    internal class CancelBetCommandHandler : ICommandHandler<CancelBetCommand>
    {
        private readonly IBetRepository _betRepository;
        private readonly IMatchesRepository _matchesRepository;
        private readonly BetCommandValidator _betCommandValidator;

        public CancelBetCommandHandler(IBetRepository betRepository, IMatchesRepository matchesRepository, BetCommandValidator betCommandValidator)
        {
            _betRepository = betRepository;
            _matchesRepository = matchesRepository;
            _betCommandValidator = betCommandValidator;
        }

        public void Handle(CancelBetCommand command)
        {
            var playerId = Guid.Parse(command.PlayerId);
            var matchId = Guid.Parse(command.MatchId);
            var bet = _betRepository.GetPlayerBet(playerId, matchId);

            if (bet == null)
            {
                throw new NullReferenceException($"Bet for PlayerId: '{command.PlayerId}' and MatchId: ' {command.MatchId} ' does not exists.");
            }

            _betCommandValidator.CheckIfMatchAlreadyStarted(bet.Match);
            _betRepository.Cancel(bet);
            bet.Player.CountPointsAfterCancel(bet.Points);
        }
    }
}
