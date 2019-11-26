using Domain.Enum;

namespace Domain.Entity
{
    public class JobOpportunity
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string Title { get; set; }
        public string Uri { get; set; }
        public string Description { get; set; }
        public JobOpportunityStatus Status { get; set; }

        public virtual Company Company { get; set; }
    }
}