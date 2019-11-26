using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class JobOpportunityConfiguration : IEntityTypeConfiguration<JobOpportunity>
    {
        public void Configure(EntityTypeBuilder<JobOpportunity> builder)
        {
            builder.HasIndex(jo => new {jo.CompanyId, jo.Uri}).IsUnique();
            builder.Property(jo => jo.Uri).IsRequired();
        }
    }
}