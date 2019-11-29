namespace Domain.Entity
{
    public class OrderCoupon
    {
        public long OrderId { get; set; }
        public long CouponId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Coupon Coupon { get; set; }
    }
}