using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class UserCompanyConfiguration : IEntityTypeConfiguration<UserCompany>
    {
        public void Configure(EntityTypeBuilder<UserCompany> builder)
        {
            builder.HasKey(oi => new { oi.UserId, oi.CompanyId });
            builder.HasOne(uc => uc.Company).WithMany(c => c.Users).HasForeignKey(uc => uc.CompanyId);
            builder.HasOne(uc => uc.User).WithMany(c => c.Companies).HasForeignKey(uc => uc.UserId);
        }
    }
}