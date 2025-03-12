using System.Collections.Generic;
using System.Linq;
using BakeryProject.Domain.Entities;

namespace BakeryProject.Infrastructure
{
    public static class DbInitializer
    {
        public static void Initialize(BakeryDbContext context)
        {
            // Seed Bread types if not already present.
            if (!context.Breads.Any())
            {
                context.Breads.AddRange(
                    new Baguette(),
                    new WhiteBread(),
                    new MilkBread(),
                    new HamburgerBun()
                );
                context.SaveChanges();
            }

            // Seed PastryChefs if not already present.
            if (!context.PastryChefs.Any())
            {
                var chefMain = new PastryChef
                {
                    Id = 1,
                    Name = "Chef Main",
                    Specialties = new List<string> { "Baguette", "White Bread" }
                };

                var chefSecond = new PastryChef
                {
                    Id = 2,
                    Name = "Chef Second",
                    Specialties = new List<string> { "Milk Bread", "Hamburger Bun" }
                };

                context.PastryChefs.AddRange(chefMain, chefSecond);
                context.SaveChanges();
            }

            // Seed BakeryOffices if not already present.
            if (!context.BakeryOffices.Any())
            {
                // Retrieve chefs (assumes they were seeded above)
                var chefMainFromDb = context.PastryChefs.FirstOrDefault(p => p.Name == "Chef Main");
                var chefSecondFromDb = context.PastryChefs.FirstOrDefault(p => p.Name == "Chef Second");

                var mainOffice = new BakeryOffice
                {
                    Id = 1,
                    Name = "Main Office",
                    MaxCapacity = 150,
                    Location = "Downtown",
                    ServiceSchedule = "Mon-Fri 8am-5pm",
                    Chef = chefMainFromDb
                };

                var secondOffice = new BakeryOffice
                {
                    Id = 2,
                    Name = "Second Office",
                    MaxCapacity = 100,
                    Location = "Suburb",
                    ServiceSchedule = "Mon-Sat 9am-4pm",
                    Chef = chefSecondFromDb
                };

                context.BakeryOffices.AddRange(mainOffice, secondOffice);
                context.SaveChanges();
            }
        }
    }
}
