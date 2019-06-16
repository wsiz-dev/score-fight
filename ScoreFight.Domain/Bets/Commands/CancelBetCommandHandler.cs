using System;
using ScoreFight.Domain.Matches;
using ScoreFight.Domain.Players;

namespace ScoreFight.Domain.Bets.Commands
{
    internal class CancelBetCommandHandler : ICommandHandler<CancelBetCommand>
    {
        private readonly IBetRepository _betRepository;
        private readonly IMatchesRepository _matchesRepository;
        private readonly IPlayersRepository _playersRepository;

        public CancelBetCommandHandler(IBetRepository betRepository, IMatchesRepository matchesRepository, IPlayersRepository playersRepository)
        {
            _betRepository = betRepository;
            _matchesRepository = matchesRepository;
            _playersRepository = playersRepository;
        }

        public void Handle(CancelBetCommand command)
        {
            var bet = _betRepository.GetPlayerBet(command.PlayerId, command.MatchId);
            if (bet == null)
            {
                throw new NullReferenceException($"Bet for PlayerId: '{command.PlayerId}' and MatchId: ' {command.MatchId} ' does not exists.");
            }

            var match = _matchesRepository.GetById(command.MatchId);
            if (match.Date <= DateTime.UtcNow)
            {
                throw new Exception($"Given match '{match.Id.ToString()}' already started.");
            }

            _betRepository.Remove(bet);

            var player = _playersRepository.GetById(command.PlayerId);
            player.RestorePoints(bet.Points);
            _playersRepository.Update(player);
        }
    }
}
