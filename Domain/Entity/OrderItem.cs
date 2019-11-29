namespace Domain.Entity
{
    public class OrderItem
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public decimal Value { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}