using System;
using ScoreFight.Domain.Bets.Validators;

namespace ScoreFight.Domain.Bets.Commands
{
    internal class UpdateBetCommandHandler : ICommandHandler<UpdateBetCommand>
    {
        private readonly IBetRepository _betRepository;
        private readonly BetCommandValidator _betCommandValidator;

        public UpdateBetCommandHandler(IBetRepository betRepository, BetCommandValidator betCommandValidator)
        {
            _betRepository = betRepository;
            _betCommandValidator = betCommandValidator;
        }

        public void Handle(UpdateBetCommand command)
        {
            var playerId = Guid.Parse(command.PlayerId);
            var matchId = Guid.Parse(command.MatchId);
            var bet = _betRepository.GetPlayerBet(playerId, matchId);

            if (bet == null)
            {
                throw new NullReferenceException($"Bet for PlayerId: '{command.PlayerId}' and MatchId: ' {command.MatchId} ' does not exists.");
            }

            _betCommandValidator.CheckIfMatchAlreadyStarted(bet.Match);

            bet.Player.CountPointsAfterBetEdit(command.PointsBet, bet.Points);
            bet.SetMatchResult(command.TeamBet);
            bet.SetPointsBet(command.PointsBet);

            _betRepository.Commit();;
        }
    }
}
