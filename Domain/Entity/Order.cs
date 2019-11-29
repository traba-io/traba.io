using System;
using System.Collections.Generic;
using Domain.Enum;

namespace Domain.Entity
{
    public class Order
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public long CompanyId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Value { get; set; }
        public decimal Discount { get; set; }
        
        public virtual User User { get; set; }
        public virtual Company Company { get; set; }
        
        public virtual List<OrderCoupon> Coupons { get; set; }
        public virtual List<OrderItem> Items { get; set; }
    }
}