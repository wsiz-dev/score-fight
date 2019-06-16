using System;
using ScoreFight.Domain.Matches;
using ScoreFight.Domain.Players;

namespace ScoreFight.Domain.Bets.Commands
{
    internal class SetBetCommandHandler : ICommandHandler<SetBetCommand>
    {
        private readonly IBetRepository _betRepository;
        private readonly IMatchesRepository _matchesRepository;
        private readonly IPlayersRepository _playersRepository;

        public SetBetCommandHandler(IBetRepository betRepository, IMatchesRepository matchesRepository, IPlayersRepository playersRepository)
        {
            _betRepository = betRepository;
            _matchesRepository = matchesRepository;
            _playersRepository = playersRepository;
        }

        public void Handle(SetBetCommand command)
        {
            if (_betRepository.Exist(command.PlayerId, command.MatchId))
            {
                throw new Exception($"Bet for PlayerId: '{command.PlayerId.ToString()}' and MatchId: '{command.MatchId.ToString()}' already exists.");
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

            var bet = new Bet
            {
                PlayerId = command.PlayerId,
                MatchId = command.MatchId,
                MatchResults = command.TeamBet,
                Points = command.PointsBet
            };

            player.CountPointsAfterBet(command.PointsBet);

            _betRepository.Save(bet);
            _playersRepository.Update(player);
        }
    }
}
