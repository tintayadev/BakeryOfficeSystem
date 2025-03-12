using BakeryProject.UI;
using BakeryProject.Application.Services;
using BakeryProject.Domain.Interfaces;
using BakeryProject.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;

namespace BakeryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=Bakery.db";
            var options = new DbContextOptionsBuilder<BakeryDbContext>()
                .UseSqlite(connectionString)
                .Options;

            using (var context = new BakeryDbContext(options))
            {
                context.Database.Migrate();

                DbInitializer.Initialize(context);

                IBakeryRepository repository = new EfBakeryRepository(context);
                IBakeryService bakeryService = new BakeryService(repository);
                IBreadFactory breadFactory = new BreadFactory(context);
                ConsoleUI ui = new ConsoleUI(bakeryService, breadFactory);
                ui.Run();
            }
        }
    }
}
