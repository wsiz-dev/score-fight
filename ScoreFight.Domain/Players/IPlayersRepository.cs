using System;

namespace ScoreFight.Domain.Players
{
    public interface IPlayersRepository
    {
        Player GetById(Guid id);
    }
}
