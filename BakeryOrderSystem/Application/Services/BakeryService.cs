using System.Linq;
using BakeryProject.Domain.Entities;
using BakeryProject.Domain.Interfaces;
using BakeryProject.Application;
using System.Collections.Generic;

namespace BakeryProject.Application.Services
{
    public class BakeryService : IBakeryService
    {
        private readonly IBakeryRepository _repository;

        public BakeryService(IBakeryRepository repository)
        {
            _repository = repository;
        }

        public BakeryOffice GetBakeryById(int id)
        {
            return _repository.GetBakeryById(id);
        }

        public void AddOrderToBakery(int bakeryId, Order order)
        {
            var bakery = _repository.GetBakeryById(bakeryId);
            if (bakery != null)
            {
                bakery.AddOrder(order);
                _repository.SaveChanges();
            }
        }

        public OrderSummary GetTotalSummary()
        {
            int totalOrders = 0;
            decimal totalRevenue = 0;
            foreach (var bakery in _repository.GetAllBakeries())
            {
                totalOrders += bakery.Orders.Where(o => !o.IsHistorical).Count();
                foreach (var order in bakery.Orders.Where(o => !o.IsHistorical))
                {
                    totalRevenue += order.TotalCost;
                }
            }
            return new OrderSummary { TotalOrders = totalOrders, TotalRevenue = totalRevenue };
        }

        public List<string> PrepareOrders(int bakeryId)
        {
            var bakery = _repository.GetBakeryById(bakeryId);
            if (bakery != null)
            {
                var log = bakery.PrepareAllOrders();
                _repository.SaveChanges();
                return log;
            }
            return new List<string>();
        }

        public FullOrderSummary GetFullSummary()
        {
            int activeCount = 0;
            decimal activeRevenue = 0;
            int historicalCount = 0;
            decimal historicalRevenue = 0;

            foreach (var bakery in _repository.GetAllBakeries())
            {
                activeCount += bakery.Orders.Where(o => !o.IsHistorical).Count();
                activeRevenue += bakery.Orders.Where(o => !o.IsHistorical).Sum(o => o.TotalCost);
                historicalCount += bakery.Orders.Where(o => o.IsHistorical).Count();
                historicalRevenue += bakery.Orders.Where(o => o.IsHistorical).Sum(o => o.TotalCost);
            }

            return new FullOrderSummary
            {
                ActiveOrdersCount = activeCount,
                ActiveOrdersRevenue = activeRevenue,
                HistoricalOrdersCount = historicalCount,
                HistoricalOrdersRevenue = historicalRevenue,
                TotalOrdersCount = activeCount + historicalCount,
                TotalRevenue = activeRevenue + historicalRevenue
            };
        }

        public List<Order> GetHistoricalOrders()
        {
            return _repository.GetHistoricalOrders().ToList();
        }
    }
}
