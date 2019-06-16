using System;

namespace ScoreFight.Domain.Bets.Commands
{
    public class CancelBetCommand : ICommand
    {
        public string PlayerId { get; }

        public string MatchId { get; }


        public CancelBetCommand(string playerId, string matchId, int teamBet, int pointsBet)
        {
            if (string.IsNullOrWhiteSpace(playerId)) throw new ArgumentException(nameof(playerId));
            PlayerId = playerId;

            if (string.IsNullOrWhiteSpace(matchId)) throw new ArgumentException(nameof(matchId));
            MatchId = matchId;
        }
    }
}
