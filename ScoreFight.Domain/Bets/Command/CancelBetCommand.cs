using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreFight.Domain.Bets.Command
{
    public class CancelBetCommand : ICommand
    {
        public string PlayerId { get; }

        public string MatchId { get; }


        public CancelBetCommand(string playerId, string matchId, int teamBet, int pointsBet)
        {
            if (string.IsNullOrWhiteSpace(playerId)) throw new ArgumentException(nameof(useplayerIdrId));
            PlayerId = playerId;

            if (string.IsNullOrWhiteSpace(matchId)) throw new ArgumentException(nameof(matchId));
            MatchId = matchId;
        }
    }
}
