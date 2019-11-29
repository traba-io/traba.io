namespace Domain.Entity
{
    public class JobOpportunityTag
    {
        public long JobOpportunityId { get; set; }
        public long TagId { get; set; }
        
        public virtual JobOpportunity JobOpportunity { get; set; }
        public virtual Tag Tag { get; set; }
    }
}