using System.Collections.Generic;
using BakeryProject.Domain.Entities;

namespace BakeryProject.Domain.Interfaces
{
    public interface IBakeryRepository
    {
        BakeryOffice GetBakeryById(int id);
        IEnumerable<BakeryOffice> GetAllBakeries();
        void UpdateBakery(BakeryOffice bakery);
        void SaveChanges();
        IEnumerable<Order> GetHistoricalOrders();
    }
}
