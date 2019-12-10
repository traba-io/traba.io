using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string Name => $"{FirstName} {LastName}";

        public virtual List<UserEvent> Events { get; set; }
        public virtual List<UserCompany> Companies { get; set; }
    }
}