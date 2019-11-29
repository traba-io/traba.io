using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        
        public virtual List<OrderItem> Sales { get; set; }
    }
}