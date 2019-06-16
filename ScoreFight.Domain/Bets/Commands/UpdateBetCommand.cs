using System;

namespace ScoreFight.Domain.Bets.Commands
{
    public class UpdateBetCommand : ICommand
    {
        public string PlayerId { get; }

        public string MatchId { get; }

        public int TeamBet { get; }

        public int PointsBet { get; }


        public UpdateBetCommand(string playerId, string matchId, int teamBet, int pointsBet)
        {
            if (string.IsNullOrWhiteSpace(playerId)) throw new ArgumentException(nameof(playerId));
            PlayerId = playerId;

            if (string.IsNullOrWhiteSpace(matchId)) throw new ArgumentException(nameof(matchId));
            MatchId = matchId;

            if (teamBet < 0) throw new ArgumentException(nameof(teamBet));
            TeamBet = teamBet;

            if (pointsBet < 0) throw new ArgumentException(nameof(pointsBet));
            PointsBet = pointsBet;
        }
    }
}
