using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScoreFight.Domain.Bets;

namespace ScoreFight.Infrastructure.EntityConfiguration
{
    internal class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder
                .HasKey(b => new { b.PlayerId, b.MatchId });

            builder
                .HasOne(b => b.Match)
                .WithMany(b => b.Bets)
                .HasForeignKey(b => b.MatchId);

            builder
                .HasOne(b => b.Player)
                .WithMany(b => b.Bets)
                .HasForeignKey(b => b.PlayerId);
        }
    }
}
