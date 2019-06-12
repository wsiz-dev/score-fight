using System;
using ScoreFight.Domain.Matches;

namespace ScoreFight.Domain.Bets.Validators
{
    public class BetCommandValidator
    {
        private readonly IBetRepository _betRepository;

        public BetCommandValidator(IBetRepository betRepository)
        {
            _betRepository = betRepository;
        }
        public void CheckIfBetAlreadyExist(Guid playerId, Guid matchId)
        {
            if (_betRepository.Exist(playerId, matchId))
            {
                throw new ArgumentException($"Bet for PlayerId: '{playerId.ToString()}' and MatchId: ' {matchId.ToString()} ' already exists.");
            }
        }

        public void CheckIfMatchDoesNotExist(Match match, string matchId)
        {
            if (match == null)
            {
                throw new NullReferenceException($"Given match '{matchId}' does not exists.");
            }
        }

        public void CheckIfMatchAlreadyStarted(Match match)
        {
            if (match.Date <= DateTime.UtcNow)
            {
                throw new ArgumentException($"Given match '{match.Id.ToString()}' already started.");
            }
        }
    }
}
