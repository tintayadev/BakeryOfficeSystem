//using System.Collections.Generic;
//using System.Linq;
//using BakeryProject.Domain.Entities;
//using BakeryProject.Domain.Interfaces;

//namespace BakeryProject.Infrastructure
//{
//    public class InMemoryBakeryRepository : IBakeryRepository
//    {
//        private List<BakeryOffice> _bakeries;

//        public InMemoryBakeryRepository()
//        {
//            _bakeries = new List<BakeryOffice>
//            {
//                new BakeryOffice
//                {
//                    Id = 1,
//                    Name = "Main Office ;D",
//                    MaxCapacity = 150,
//                    Location = "Sopocachi",
//                    ServiceSchedule = "Mon-Fri 8am-5pm",
//                    Chef = new PastryChef { Id = 1, Name = "Chef Paulo", Specialties = new List<string> { "Baguette", "White Bread", "Milk Bread" } }
//                },
//                new BakeryOffice
//                {
//                    Id = 2,
//                    Name = "Second Office :|",
//                    MaxCapacity = 100,
//                    Location = "San Miguel",
//                    ServiceSchedule = "Mon-Sat 9am-4pm",
//                    Chef = new PastryChef { Id = 2, Name = "Chef Emanuel", Specialties = new List<string> { "Baguette", "White Bread", "Hamburger Bun" } }
//                }
//            };
//        }

//        public BakeryOffice GetBakeryById(int id)
//        {
//            return _bakeries.FirstOrDefault(b => b.Id == id);
//        }

//        public IEnumerable<BakeryOffice> GetAllBakeries() => _bakeries;
//        public void UpdateBakery(BakeryOffice bakery) { }
//    }
//}
