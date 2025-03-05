using System.Collections.Generic;
using System.Linq;
using BakeryProject.Domain.Entities;
using BakeryProject.Domain.Interfaces;

namespace BakeryProject.Infrastructure
{
    public class InMemoryBakeryRepository : IBakeryRepository
    {
        private List<BakeryOffice> _bakeries;

        public InMemoryBakeryRepository()
        {
            _bakeries = new List<BakeryOffice>
            {
                new BakeryOffice
                {
                    Id = 1,
                    Name = "Main Office",
                    MaxCapacity = 150,
                    Chef = new PastryChef { Id = 1, Name = "Chef Main", Specialties = new List<string> { "Baguette", "White Bread" } }
                },
                new BakeryOffice
                {
                    Id = 2,
                    Name = "Second Office",
                    MaxCapacity = 100,
                    Chef = new PastryChef { Id = 2, Name = "Chef Second", Specialties = new List<string> { "Milk Bread", "Hamburger Bun" } }
                }
            };
        }

        public BakeryOffice GetBakeryById(int id)
        {
            return _bakeries.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<BakeryOffice> GetAllBakeries() => _bakeries;

        public void UpdateBakery(BakeryOffice bakery)
        {
            // In an in-memory repository, changes are already reflected.
        }
    }
}
