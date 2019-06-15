using System;
using ScoreFight.Domain.Bets.Validators;

namespace ScoreFight.Domain.Bets.Command
{
    internal class CancelBetCommandHandler : ICommandHandler<CancelBetCommand>
    {
        private readonly IBetRepository _betRepository;
        private readonly BetCommandValidator _betCommandValidator;

        public CancelBetCommandHandler(IBetRepository betRepository, BetCommandValidator betCommandValidator)
        {
            _betRepository = betRepository;
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
