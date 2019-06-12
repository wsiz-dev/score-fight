using System;
using ScoreFight.Domain.Bets.Validators;
using ScoreFight.Domain.Matches;

namespace ScoreFight.Domain.Bets.Command
{
    public class UpdateBetCommandHandler : ICommandHandler<UpdateBetCommand>
    {
        private readonly IBetRepository _betRepository;
        private readonly IMatchesRepository _matchesRepository;
        private readonly BetCommandValidator _betCommandValidator;

        public UpdateBetCommandHandler(IBetRepository betRepository, IMatchesRepository matchesRepository, BetCommandValidator betCommandValidator)
        {
            _betRepository = betRepository;
            _matchesRepository = matchesRepository;
            _betCommandValidator = betCommandValidator;
        }

        public void Handle(UpdateBetCommand command)
        {
            var userId = Guid.Parse(command.PlayerId);
            var matchId = Guid.Parse(command.MatchId);
            var match = _matchesRepository.GetById(matchId);

            _betCommandValidator.CheckIfMatchDoesNotExist(match, command.MatchId);
            _betCommandValidator.CheckIfMatchAlreadyStarted(match);

            var bet = _betRepository.GetBet(userId, matchId);

            if (bet == null)
            {
                throw new NullReferenceException($"Bet for PlayerId: '{command.PlayerId}' and MatchId: ' {command.MatchId} ' does not exists.");
            }

            _betRepository.Save(bet);
        }
    }
}
