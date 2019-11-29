using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class JobOpportunityTagConfiguration : IEntityTypeConfiguration<JobOpportunityTag>
    {
        public void Configure(EntityTypeBuilder<JobOpportunityTag> builder)
        {
            builder.HasKey(jo => new {jo.JobOpportunityId, jo.TagId});
            builder.HasOne(jo => jo.Tag).WithMany(t => t.JobOpportunities).HasForeignKey(jo => jo.TagId);
            builder.HasOne(jo => jo.JobOpportunity).WithMany(t => t.Tags).HasForeignKey(jo => jo.JobOpportunityId);
        }
    }
}