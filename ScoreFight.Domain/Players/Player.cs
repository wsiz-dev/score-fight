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
    }
}
