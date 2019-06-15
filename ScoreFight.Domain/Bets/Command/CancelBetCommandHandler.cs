using System;
using System.Collections.Generic;
using System.Text;
using ScoreFight.Domain.Bets.Validators;
using ScoreFight.Domain.Matches;

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
            var userId = Guid.Parse(command.PlayerId);
            var matchId = Guid.Parse(command.MatchId);
            var bet = _betRepository.GetBet(userId, matchId);

            if (bet == null)
            {
                throw new NullReferenceException($"Bet for PlayerId: '{command.PlayerId}' and MatchId: ' {command.MatchId} ' does not exists.");
            }

            _betCommandValidator.CheckIfMatchAlreadyStarted(bet.Matches);
            _betRepository.Cancel(bet);
        }
    }
}
