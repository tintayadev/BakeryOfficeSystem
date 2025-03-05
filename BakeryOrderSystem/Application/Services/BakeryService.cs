using System.Collections.Generic;
using BakeryProject.Domain.Entities;
using BakeryProject.Domain.Interfaces;
using BakeryProject.Application;

namespace BakeryProject.Application.Services
{
    public class BakeryService : IBakeryService
    {
        private readonly IBakeryRepository _repository;
        private int _totalOrders;         
        private decimal _totalRevenue;
        
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
                _totalOrders++;
                _totalRevenue += order.TotalCost;
                _repository.UpdateBakery(bakery);
            }
        }

        public OrderSummary GetTotalSummary()
        {
            return new OrderSummary { TotalOrders = _totalOrders, TotalRevenue = _totalRevenue };
        }

        public List<string> PrepareOrders(int bakeryId)
        {
            var bakery = _repository.GetBakeryById(bakeryId);
            if (bakery != null)
            {
                var log = bakery.PrepareAllOrders();
                _repository.UpdateBakery(bakery);
                return log;
            }
            return new List<string>();
        }
    }
}
