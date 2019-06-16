using System;
using ScoreFight.Domain.Bets;
using ScoreFight.Domain.Bets.Services.Interfaces;
using ScoreFight.Domain.Players;

namespace ScoreFight.Domain.Matches.Commands
{
    internal class EndMatchCommandHandler : ICommandHandler<EndMatchCommand>
    {
        private readonly IMatchesRepository _matchesRepository;
        private readonly IBetRepository _betRepository;
        private readonly IPlayersRepository _playersRepository;
        private readonly IPointService _pointService;

        public EndMatchCommandHandler(IMatchesRepository matchesRepository, IBetRepository betRepository, IPlayersRepository playersRepository, IPointService pointService)
        {
            _matchesRepository = matchesRepository;
            _betRepository = betRepository;
            _playersRepository = playersRepository;
            _pointService = pointService;
        }

        public void Handle(EndMatchCommand command)
        {
            var match = _matchesRepository.GetById(command.MatchId);
            CheckIfMatchExist(match, command.MatchId);
            match.SetResult(command.MatchResult);

            var bets = _betRepository.GetBetsByMatchId(command.MatchId);
            if (bets == null)
            {
                return;
            }

            _pointService.CountPointsAfterMatch(bets, command.MatchResult);
            _matchesRepository.Commit();
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
