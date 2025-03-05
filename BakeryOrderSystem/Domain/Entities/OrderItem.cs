namespace BakeryProject.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Bread Bread { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal => UnitPrice * Quantity;
    }
}
