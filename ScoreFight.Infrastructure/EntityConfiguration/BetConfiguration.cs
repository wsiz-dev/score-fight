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
                .HasKey(b => new { b.UserId, b.MatchId });

            builder
                .HasOne(b => b.Matches)
                .WithMany(b => b.Bets)
                .HasForeignKey(b => b.MatchId);

            builder
                .HasOne(b => b.Users)
                .WithMany(b => b.Bets)
                .HasForeignKey(b => b.UserId);
        }
    }
}
