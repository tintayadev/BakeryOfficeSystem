using System;
using BakeryProject.Domain.Entities;
using BakeryProject.Domain.Interfaces;
using BakeryProject.Application;

namespace BakeryProject.UI
{
    public class ConsoleUI
    {
        private readonly IBakeryService _bakeryService;
        private readonly IBreadFactory _breadFactory;

        public ConsoleUI(IBakeryService bakeryService, IBreadFactory breadFactory)
        {
            _bakeryService = bakeryService;
            _breadFactory = breadFactory;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Bakery Fresh Bread Management ===");
                Console.WriteLine("1. Manage Main Office");
                Console.WriteLine("2. Manage Second Office");
                Console.WriteLine("3. View Total Orders and Revenue");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");
                try
                {
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            ManageBakery(1);
                            break;
                        case "2":
                            ManageBakery(2);
                            break;
                        case "3":
                            ShowTotalSummary();
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Invalid option. Press any key to continue.");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
            }
        }

        private void ManageBakery(int bakeryId)
        {
            var bakery = _bakeryService.GetBakeryById(bakeryId);
            if (bakery == null)
            {
                Console.WriteLine("Bakery not found.");
                return;
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"=== {bakery.Name} ===");
                Console.WriteLine("1. Add Order");
                if (bakery.Orders.Count > 0)
                    Console.WriteLine("2. Prepare All Orders");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Select an option: ");
                try
                {
                    string choice = Console.ReadLine();
                    if (choice == "0")
                        break;
                    else if (choice == "1")
                        AddOrderWorkflow(bakery);
                    else if (choice == "2" && bakery.Orders.Count > 0)
                        PrepareOrdersWorkflow(bakery);
                    else
                    {
                        Console.WriteLine("Invalid option. Press any key to continue.");
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
            }
        }

        private void AddOrderWorkflow(BakeryOffice bakery)
        {
            try
            {
                Order order = new Order { Id = GenerateOrderId() };
                bool addingItems = true;
                while (addingItems)
                {
                    Console.Clear();
                    Console.WriteLine($"=== Add Order to {bakery.Name} ===");
                    Console.WriteLine("Select Bread Type:");
                    Console.WriteLine("1. Baguette");
                    Console.WriteLine("2. White Bread");
                    Console.WriteLine("3. Milk Bread");
                    Console.WriteLine("4. Hamburger Bun");
                    Console.Write("Your choice: ");
                    if (!int.TryParse(Console.ReadLine(), out int breadChoice))
                    {
                        Console.WriteLine("Invalid input. Press any key to try again.");
                        Console.ReadKey();
                        continue;
                    }
                    Bread bread;
                    try
                    {
                        bread = _breadFactory.CreateBread(breadChoice);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}. Press any key to try again.");
                        Console.ReadKey();
                        continue;
                    }
                    Console.Write("Enter quantity: ");
                    if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
                    {
                        Console.WriteLine("Invalid quantity. Press any key to try again.");
                        Console.ReadKey();
                        continue;
                    }
                    OrderItem item = new OrderItem
                    {
                        Bread = bread,
                        Quantity = quantity,
                        UnitPrice = bread.Price
                    };

                    if (order.TotalBreadCount() + item.Quantity > bakery.GetRemainingCapacity())
                    {
                        Console.WriteLine($"Cannot add item. Exceeds capacity. Remaining capacity: {bakery.GetRemainingCapacity()} breads.");
                        Console.WriteLine("Press any key to return to bakery menu.");
                        Console.ReadKey();
                        return;
                    }
                    order.Items.Add(item);

                    Console.Write("Add another bread to this order? (y/n): ");
                    string another = Console.ReadLine();
                    if (another.ToLower() != "y")
                        addingItems = false;
                }
                order.TotalCost = order.CalculateTotalCost();
                Console.WriteLine($"Order Total Cost: ${order.TotalCost}");
                Console.Write("Confirm order? (y/n): ");
                string confirm = Console.ReadLine();
                if (confirm.ToLower() == "y")
                {
                    _bakeryService.AddOrderToBakery(bakery.Id, order);
                    Console.WriteLine("Order added successfully! Press any key to continue.");
                }
                else
                {
                    Console.WriteLine("Order cancelled. Press any key to continue.");
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding order: {ex.Message}");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }

        private void PrepareOrdersWorkflow(BakeryOffice bakery)
        {
            try
            {
                Console.Clear();
                Console.WriteLine($"=== Preparing Orders for {bakery.Name} ===");
                var log = _bakeryService.PrepareOrders(bakery.Id);
                foreach (var line in log)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine("All orders have been prepared. Press any key to continue.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error preparing orders: {ex.Message}");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }

        private void ShowTotalSummary()
        {
            try
            {
                Console.Clear();
                var summary = _bakeryService.GetTotalSummary();
                Console.WriteLine("=== Total Orders and Revenue ===");
                Console.WriteLine($"Total Orders: {summary.TotalOrders}");
                Console.WriteLine($"Total Revenue: ${summary.TotalRevenue}");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }

        private int GenerateOrderId()
        {
            return new Random().Next(1000, 9999);
        }
    }
}
