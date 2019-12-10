namespace Domain.Entity
{
    public class UserEvent
    {
        public string UserId { get; set; }
        public long EventId { get; set; }
        public bool Owner { get; set; }
        
        public virtual User User { get; set; }
        public virtual Event Event { get; set; }
    }
}