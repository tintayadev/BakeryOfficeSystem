using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryProject.Domain.Entities
{
    public class BakeryOffice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public PastryChef Chef { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

        public int GetCurrentBreadCount() => Orders.Sum(o => o.TotalBreadCount());

        public int GetRemainingCapacity() => MaxCapacity - GetCurrentBreadCount();

        public bool CanAddOrder(Order order)
        {
            return order.TotalBreadCount() <= GetRemainingCapacity();
        }

        public List<string> PrepareAllOrders()
        {
            List<string> preparationLog = new List<string>();
            foreach (var order in Orders)
            {
                preparationLog.Add($"Preparing Order {order.Id} created at {order.CreatedAt}:");
                foreach (var item in order.Items)
                {
                    preparationLog.Add($"- {item.Quantity} x {item.Bread.Name}:");
                    var steps = item.Bread.GetPreparationSteps(item.Quantity);
                    foreach (var step in steps)
                    {
                        preparationLog.Add($"   {step}");
                    }
                }
                order.IsPrepared = true;
            }
            Orders.Clear();
            return preparationLog;
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

    }
}
