namespace ScoreFight.Domain.Players
{
    public class RankingPosition
    {
        public RankingPosition(int orderNumber, Player player)
        {
            OrderNumber = orderNumber;
            Login = player.Login;
            Level = player.Level;
            MaxLevel = player.MaxLevel;
            Points = player.Points;
        }

        public int OrderNumber { get; }
        public string Login { get; }
        public int Level { get; }
        public int MaxLevel { get; }
        public int Points { get; }
    }
}
