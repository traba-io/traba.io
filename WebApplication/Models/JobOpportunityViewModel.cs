using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public class JobOpportunityViewModel
    {
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public string Description { get; set; }
        public DateTime AvailableUntil { get; set; }
        public long CompanyId { get; set; }
    }
}