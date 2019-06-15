using System;
using ScoreFight.Domain.Bets.Validators;
using ScoreFight.Domain.Matches;
using ScoreFight.Domain.Players;

namespace ScoreFight.Domain.Bets.Command
{
    internal class UpdateBetCommandHandler : ICommandHandler<UpdateBetCommand>
    {
        private readonly IBetRepository _betRepository;
        private readonly IMatchesRepository _matchesRepository;
        private readonly BetCommandValidator _betCommandValidator;
        private readonly IPlayersRepository _playersRepository;

        public UpdateBetCommandHandler(IBetRepository betRepository, IMatchesRepository matchesRepository, BetCommandValidator betCommandValidator, IPlayersRepository playersRepository)
        {
            _betRepository = betRepository;
            _matchesRepository = matchesRepository;
            _betCommandValidator = betCommandValidator;
            _playersRepository = playersRepository;
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

            var player = _playersRepository.GetById(playerId);
            player.CountPointsAfterBetEdit(command.PointsBet, bet.Points);
            bet.SetMatchResult(command.TeamBet);
            bet.SetPointsBet(command.PointsBet);

            _betRepository.Commit();;
        }
    }
}
