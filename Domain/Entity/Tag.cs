using System.Collections.Generic;

namespace Domain.Entity
{
    public class Tag
    {
        public long Id { get; set; }
        public string Name { get; set; }
        
        public virtual List<JobOpportunityTag> JobOpportunities { get; set; }
    }
}