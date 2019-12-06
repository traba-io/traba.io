namespace Domain.Entity
{
    public class UserCompany
    {
        public string UserId { get; set; }
        public long CompanyId { get; set; }
        public bool Owner { get; set; }
        public virtual User User { get; set; }
        public virtual Company Company { get; set; }
    }
}