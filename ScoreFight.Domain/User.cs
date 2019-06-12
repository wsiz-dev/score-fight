using System;
using System.Collections.Generic;
using ScoreFight.Domain.Bets;

namespace ScoreFight.Domain
{
    public class User
    {
        public Guid Id { get; protected set; }

        public virtual ICollection<Bet> Bets { get; protected set; }
    }
}
