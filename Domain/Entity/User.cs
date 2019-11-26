using Microsoft.AspNetCore.Identity;

namespace Domain.Entity
{
    public class User : IdentityUser
    {
        public long CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Company Company { get; set; }
    }
}