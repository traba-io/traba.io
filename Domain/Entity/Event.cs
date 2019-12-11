using System;
using System.Collections.Generic;
using Domain.Abstract;

namespace Domain.Entity
{
    public class Event : BaseEntity
    {
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public virtual List<UserEvent> Users { get; set; }
    }
}