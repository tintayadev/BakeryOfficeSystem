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
        public string Location { get; set; }
        public string ServiceSchedule { get; set; }
        public PastryChef Chef { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

        public int GetCurrentBreadCount() => Orders.Where(o => !o.IsHistorical).Sum(o => o.TotalBreadCount());
        public int GetRemainingCapacity() => MaxCapacity - GetCurrentBreadCount();
        public bool CanAddOrder(Order order) => order.TotalBreadCount() <= GetRemainingCapacity();

        public void AddOrder(Order order)
        {
            order.BakeryOfficeId = this.Id;
            Orders.Add(order);
        }

        public List<string> PrepareAllOrders()
        {
            List<string> preparationLog = new List<string>();
            var activeOrders = Orders.Where(o => !o.IsHistorical).ToList();
            foreach (var order in activeOrders)
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
                order.IsHistorical = true;
            }
            return preparationLog;
        }
    }
}
