using System;
using ScoreFight.Domain.Bets.Enums;
using ScoreFight.Domain.Bets.Services.Interfaces;
using ScoreFight.Domain.Matches;

namespace ScoreFight.Domain.Bets.Command
{
    public class SetBetCommandHandler : ICommandHandler<SetBetCommand>
    {
        private readonly IBetRepository _betRepository;
        private readonly IMatchesRepository _matchesRepository;
        private readonly IBetService _betService;

        public SetBetCommandHandler(IBetRepository betRepository, IMatchesRepository matchesRepository, IBetService betService)
        {
            _betRepository = betRepository;
            _matchesRepository = matchesRepository;
            _betService = betService;
        }
        public void Handle(SetBetCommand command)
        {
            var playerId = Guid.Parse(command.PlayerId);
            var matchId = Guid.Parse(command.MatchId);

            _betService.CheckIfBetAlreadyExist(playerId, matchId);

            var match = _matchesRepository.GetById(matchId);

            _betService.CheckIfMatchDoesNotExist(match, command.MatchId);
            _betService.CheckIfMatchAlreadyStarted(match);

            var bet = new Bet(playerId, matchId, (TeamBet)command.TeamBet, command.PointsBet);

            _betRepository.Save(bet);
        }

    }
}
