using System.Collections.Generic;
using System.Linq;
using ScoreFight.Domain.Bets.Services.Interfaces;
using ScoreFight.Domain.Matches;
using ScoreFight.Domain.Players;

namespace ScoreFight.Domain.Bets.Services
{
    public class PointService : IPointService
    {
        private readonly IPlayersRepository _playersRepository;

        public PointService(IPlayersRepository playersRepository)
        {
            _playersRepository = playersRepository;
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
                bet.Player.AddPointsAfterWin(bet.Points, lockedPoints, pointsToDistribute);
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
    }
}
