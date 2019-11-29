using System;
using System.Collections.Generic;
using Domain.Enum;

namespace Domain.Entity
{
    public class Coupon
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }
        public CouponType Type { get; set; }
        public CouponState State { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual List<OrderCoupon> Orders { get; set; }
    }
}