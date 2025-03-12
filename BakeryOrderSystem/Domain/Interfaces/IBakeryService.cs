using System.Collections.Generic;
using BakeryProject.Domain.Entities;
using BakeryProject.Application;

namespace BakeryProject.Domain.Interfaces
{
    public interface IBakeryService
    {
        BakeryOffice GetBakeryById(int id);
        void AddOrderToBakery(int bakeryId, Order order);
        OrderSummary GetTotalSummary();
        List<string> PrepareOrders(int bakeryId);
        List<Order> GetHistoricalOrders();

        FullOrderSummary GetFullSummary();
    }
}
