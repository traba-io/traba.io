using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class OrderCouponConfiguration : IEntityTypeConfiguration<OrderCoupon>
    {
        public void Configure(EntityTypeBuilder<OrderCoupon> builder)
        {
            builder.HasKey(oc => new {oc.CouponId, oc.OrderId});
            builder.HasOne(oc => oc.Coupon).WithMany(c => c.Orders).HasForeignKey(oc => oc.CouponId);
            builder.HasOne(oc => oc.Order).WithMany(o => o.Coupons).HasForeignKey(oc => oc.OrderId);
        }
    }
}