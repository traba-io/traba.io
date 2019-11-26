using System;
using Domain.Abstract;
using Domain.Enum;

namespace Domain.Entity
{
    public class JobOpportunity : BaseEntity
    {
        public long CompanyId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Uri { get; set; }
        public string Excerpt { get; set; }
        public string Description { get; set; }
        public DateTime? AvailableUntil { get; set; }
        public JobOpportunityStatus Status { get; set; }

        public virtual Company Company { get; set; }
        public virtual User User { get; set; }
    }
}