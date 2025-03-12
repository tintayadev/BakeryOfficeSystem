using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryProject.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal TotalCost { get; set; }
        public bool IsPrepared { get; set; } = false;
        public bool IsHistorical { get; set; } = false;

        public int BakeryOfficeId { get; set; }

        public int TotalBreadCount() => Items.Sum(item => item.Quantity);
        public decimal CalculateTotalCost() => Items.Sum(item => item.Subtotal);
    }
}
