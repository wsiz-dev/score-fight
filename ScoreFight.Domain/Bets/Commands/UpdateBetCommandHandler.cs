using System;
using ScoreFight.Domain.Matches;
using ScoreFight.Domain.Players;

namespace ScoreFight.Domain.Bets.Commands
{
    internal class UpdateBetCommandHandler : ICommandHandler<UpdateBetCommand>
    {
        private readonly IBetRepository _betRepository;
        private readonly IMatchesRepository _matchesRepository;
        private readonly IPlayersRepository _playersRepository;

        public UpdateBetCommandHandler(IBetRepository betRepository, IMatchesRepository matchesRepository, IPlayersRepository playersRepository)
        {
            _betRepository = betRepository;
            _matchesRepository = matchesRepository;
            _playersRepository = playersRepository;
        }

        public void Handle(UpdateBetCommand command)
        {
            var bet = _betRepository.GetPlayerBet(command.PlayerId, command.MatchId);
            if (bet == null)
            {
                throw new NullReferenceException($"Bet for PlayerId: '{command.PlayerId}' and MatchId: ' {command.MatchId} ' does not exists.");
            }

            var match = _matchesRepository.GetById(command.MatchId);
            if (match == null)
            {
                throw new NullReferenceException($"Given match '{command.MatchId.ToString()}' does not exists.");
            }

            if (match.Date <= DateTime.UtcNow)
            {
                throw new Exception($"Given match '{match.Id.ToString()}' already started.");
            }

            var player = _playersRepository.GetById(command.PlayerId);
            if (player == null)
            {
                throw new NullReferenceException($"Given player '{command.PlayerId.ToString()}' does not exists.");
            }

            player.CountPointsAfterBetEdit(command.PointsBet, bet.Points);
            bet.MatchResults = command.TeamBet;
            bet.Points = command.PointsBet;

            _betRepository.Save(bet);
            _playersRepository.Update(player);
        }
    }
}
