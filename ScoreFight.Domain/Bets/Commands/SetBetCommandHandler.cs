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

            var bet = _betRepository.GetPlayerBet(command.PlayerId, command.MatchId);
            if (bet != null)
            {
                player.RestorePoints(bet.Points);
                player.SpendPoints(command.Points);

                bet.MatchResult = command.MatchResult;
                bet.Points = command.Points;

                _betRepository.Update(bet);
            }
            else
            {
                bet = new Bet
                {
                    PlayerId = command.PlayerId,
                    MatchId = command.MatchId,
                    MatchResult = command.MatchResult,
                    Points = command.Points
                };

                player.SpendPoints(command.Points);

                _betRepository.Add(bet);
            }
            
            _playersRepository.Update(player);
        }
    }
}
