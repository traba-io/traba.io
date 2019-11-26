using System;
using System.Collections.Generic;
using Domain.Abstract;

namespace Domain.Entity
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Uri { get; set; }
        public string Description { get; set; }

        public virtual List<User> Users { get; set; }
    }
}