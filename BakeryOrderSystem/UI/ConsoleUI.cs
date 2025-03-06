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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bakery not found.");
                Console.ResetColor();
                return;
            }
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"=== {bakery.Name} ===");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Location: {bakery.Location}");
                Console.WriteLine($"Service Schedule: {bakery.ServiceSchedule}");
                Console.WriteLine($"Pastry Chef: {bakery.Chef.Name}");
                Console.WriteLine("Specialties: " + string.Join(", ", bakery.Chef.Specialties));
                Console.ResetColor();
                Console.WriteLine();

                if (bakery.Orders.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Current Orders:");
                    int orderNumber = 1;
                    foreach (var order in bakery.Orders)
                    {
                        Console.WriteLine($"{orderNumber}. Order #{order.Id} (Created: {order.CreatedAt})");
                        Console.Write("   Items: ");
                        foreach (var item in order.Items)
                        {
                            Console.Write($"{item.Quantity} x {item.Bread.Name}, ");
                        }
                        Console.WriteLine();
                        Console.WriteLine($"   Total Cost: ${order.TotalCost}");
                        orderNumber++;
                    }
                    Console.ResetColor();
                    Console.WriteLine();
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Options:");
                Console.WriteLine("1. Add Order");
                if (bakery.Orders.Count > 0)
                    Console.WriteLine("2. Prepare All Orders");
                Console.WriteLine("0. Back to Main Menu");
                Console.ResetColor();
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option. Press any key to continue.");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("Press any key to continue.");
                    Console.ResetColor();
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
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"=== Add Order to {bakery.Name} ===");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Available Bread Options:");
                    var availableBreads = bakery.Chef.Specialties;
                    int optionNumber = 1;
                    var breadOptions = new Dictionary<int, string>();
                    foreach (var breadName in availableBreads)
                    {
                        Bread tempBread = _breadFactory.CreateBread(breadName);
                        Console.WriteLine($"{optionNumber}. {breadName} - Price: ${tempBread.Price}");
                        breadOptions.Add(optionNumber, breadName);
                        optionNumber++;
                    }
                    Console.ResetColor();

                    Console.Write("Select an option: ");
                    if (!int.TryParse(Console.ReadLine(), out int selectedOption) || !breadOptions.ContainsKey(selectedOption))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option. Press any key to try again.");
                        Console.ResetColor();
                        Console.ReadKey();
                        continue;
                    }
                    string selectedBreadName = breadOptions[selectedOption];
                    Bread bread;
                    try
                    {
                        bread = _breadFactory.CreateBread(selectedBreadName);
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Error: {ex.Message}. Press any key to try again.");
                        Console.ResetColor();
                        Console.ReadKey();
                        continue;
                    }
                    Console.Write("Enter quantity: ");
                    if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid quantity. Press any key to try again.");
                        Console.ResetColor();
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Cannot add item. Exceeds capacity. Remaining capacity: {bakery.GetRemainingCapacity()} breads.");
                        Console.WriteLine("Press any key to return to bakery menu.");
                        Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Order Total Cost: ${order.TotalCost}");
                Console.Write("Confirm order? (y/n): ");
                Console.ResetColor();
                string confirm = Console.ReadLine();
                if (confirm.ToLower() == "y")
                {
                    _bakeryService.AddOrderToBakery(bakery.Id, order);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Order added successfully! Press any key to continue.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Order cancelled. Press any key to continue.");
                    Console.ResetColor();
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error adding order: {ex.Message}");
                Console.WriteLine("Press any key to continue.");
                Console.ResetColor();
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
