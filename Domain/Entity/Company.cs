using System;
using System.Collections.Generic;
using Domain.Abstract;

namespace Domain.Entity
{
    public class Company : BaseEntity
    {
        public Company()
        {
            Users = new List<UserCompany>();
        }
        
        public string Name { get; set; }
        public string Document { get; set; }
        public string Namespace { get; set; }
        public string ProfilePicture { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }

        public string Email { get; set; }

        //Address fields.
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Complementary { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string ZipCode { get; set; }

        public virtual List<UserCompany> Users { get; set; }
    }
}