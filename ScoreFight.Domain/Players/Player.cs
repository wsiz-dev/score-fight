using System;
using System.Collections.Generic;
using ScoreFight.Domain.Bets;

namespace ScoreFight.Domain.Players
{
    public class Player
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public int Level { get; set; }

        public int MaxLevel { get; set; }

        public int Points { get; set; }

        public int Wins { get; set; }

        public int Loses { get; set; }

        public virtual ICollection<Bet> Bets { get; protected set; }

        public void AddPointsAfterWin(int points, int lockedPoints, int pointsToDistribute)
        {
            if (lockedPoints == 0)
            {
                Points += points;
                return;
            }

            var participationPoints = (double)points / lockedPoints;
            var pointsEarned = pointsToDistribute * participationPoints;
            Points += (int)pointsEarned;
        }

        public void CountPointsAfterBet(int points)
        {
            if (points >= Points)
            {
                throw  new ArgumentException($"Not enough points. You bet: ' {points} 'points. Your number of points is: ' {Points} '.");
            }
            Points -= points;
        }

    }

}
