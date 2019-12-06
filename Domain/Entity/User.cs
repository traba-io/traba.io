using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual List<UserCompany> Companies { get; set; }
    }
}