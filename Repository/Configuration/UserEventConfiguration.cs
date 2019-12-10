using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class UserEventConfiguration : IEntityTypeConfiguration<UserEvent>
    {
        public void Configure(EntityTypeBuilder<UserEvent> builder)
        {
            builder.HasKey(oi => new { oi.UserId, oi.EventId });
            builder.HasOne(uc => uc.Event).WithMany(c => c.Users).HasForeignKey(uc => uc.EventId);
            builder.HasOne(uc => uc.User).WithMany(c => c.Events).HasForeignKey(uc => uc.UserId);
        }
    }
}