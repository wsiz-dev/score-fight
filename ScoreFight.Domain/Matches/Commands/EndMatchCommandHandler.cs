using System;
using System.Collections.Generic;
using System.Linq;
using ScoreFight.Domain.Bets;
using ScoreFight.Domain.Players;

namespace ScoreFight.Domain.Matches.Commands
{
    internal class EndMatchCommandHandler : ICommandHandler<EndMatchCommand>
    {
        private readonly IMatchesRepository _matchesRepository;
        private readonly IBetRepository _betRepository;
        private readonly IPlayersRepository _playersRepository;

        public EndMatchCommandHandler(IMatchesRepository matchesRepository, IBetRepository betRepository, IPlayersRepository playersRepository)
        {
            _matchesRepository = matchesRepository;
            _betRepository = betRepository;
            _playersRepository = playersRepository;
        }

        public void Handle(EndMatchCommand command)
        {
            var match = _matchesRepository.GetById(command.MatchId);
            CheckIfMatchExist(match, command.MatchId);
            match.Result = command.MatchResult;

            var bets = _betRepository.GetBetsByMatchId(command.MatchId);
            if (bets == null)
            {
                return;
            }

            CountPointsAfterMatch(bets, command.MatchResult);
            _matchesRepository.Commit();
        }

        public void CountPointsAfterMatch(ICollection<Bet> bets, MatchResults result)
        {
            var allPoints = SetAllPoints(bets);
            var pointsToDistribute = SetPointsToDistribute(bets, result);
            var lockedPoints = allPoints - pointsToDistribute;

            foreach (var bet in bets)
            {
                if (bet.MatchResults != result)
                {
                    continue;
                }

                var player = _playersRepository.GetById(bet.PlayerId);
                player.AddPointsAfterWin(bet.Points, lockedPoints, pointsToDistribute);
            }
        }

        private static int SetAllPoints(IEnumerable<Bet> bets)
        {
            return bets.Sum(bet => bet.Points);
        }

        private static int SetPointsToDistribute(IEnumerable<Bet> bets, MatchResults result)
        {
            return bets.Where(bet => bet.MatchResults == result)
                .Sum(bet => bet.Points);
        }

        private static void CheckIfMatchExist(Match match, Guid matchId)
        {
            if (match == null)
            {
                throw new ArgumentNullException($"Given match: '{matchId}' does not exists.");
            }
        }
    }
}
