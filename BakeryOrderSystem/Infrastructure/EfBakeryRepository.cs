using System.Collections.Generic;
using System.Linq;
using BakeryProject.Domain.Entities;
using BakeryProject.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BakeryProject.Infrastructure
{
    public class EfBakeryRepository : IBakeryRepository
    {
        private readonly BakeryDbContext _context;

        public EfBakeryRepository(BakeryDbContext context)
        {
            _context = context;
        }

        public BakeryOffice GetBakeryById(int id)
        {
            return _context.BakeryOffices
                .Include(b => b.Chef)
                .Include(b => b.Orders)
                    .ThenInclude(o => o.Items)
                        .ThenInclude(oi => oi.Bread)
                .FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<BakeryOffice> GetAllBakeries()
        {
            return _context.BakeryOffices
                .Include(b => b.Chef)
                .Include(b => b.Orders)
                    .ThenInclude(o => o.Items)
                        .ThenInclude(oi => oi.Bread)
                .ToList();
        }

        public void UpdateBakery(BakeryOffice bakery)
        {
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetHistoricalOrders()
        {
            return _context.Orders
                .Where(o => o.IsHistorical)
                .Include(o => o.Items)
                    .ThenInclude(oi => oi.Bread)
                .ToList();
        }
    }
}
