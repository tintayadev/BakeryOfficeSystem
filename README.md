
## Features Implemented
- **Order Management:**  
  - Add orders with multiple bread types and quantities.
  - Validate that the total number of breads does not exceed the office's capacity.
  - Confirm or cancel orders through interactive prompts.

- **Bread Preparation Simulation:**  
  - Simulate the preparation process of breads (Baguette, White Bread, Milk Bread, Hamburger Bun) by printing the preparation steps.
  - Option to prepare all orders for an office, which clears the active order list.

- **Capacity and Summary Reporting:**  
  - Each bakery office has a set capacity (150 for Main Office, 100 for Second Office).
  - Display a historical summary of the total orders and revenue generated, even after orders are cleared upon preparation.

- **Enhanced Architecture and Design Patterns:**  
  - **Factory Pattern:** Used for creating bread objects via a BreadFactory.
  - **Repository Pattern:** An in-memory repository abstracts data storage.
  - **Clean Architecture & SOLID Principles:** The solution is divided into separate layers (Domain, Infrastructure, Application, UI) for maintainability and extensibility.
  - **Error Handling:** Extensive input validation and try-catch blocks ensure robust runtime error management.

## Architecture and Project Structure
```
BakeryProject/
│
├── Program.cs                     // Entry point of the application
├── Domain/                        // Contains domain entities and interfaces
│   ├── Entities/                  // BakeryOffice, Order, OrderItem, Ingredient, Bread and its concrete implementations, PastryChef
│   └── Interfaces/                // IBreadFactory, IBakeryRepository, IBakeryService
├── Infrastructure/                // InMemoryBakeryRepository implementation
├── Application/                   // Business logic, BakeryService, BreadFactory, OrderSummary
└── UI/                           // Console user interface (ConsoleUI)
```

## Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (version 5.0 or later recommended)
- A code editor or IDE (such as Visual Studio or Visual Studio Code)

## Running the Project
1. **Clone or download** the project repository to your local machine.
2. Open a terminal (or command prompt) and navigate to the project's root directory.
3. Build the project by running:
   ```bash
   dotnet build
   ```
4. Run the application with:
   ```bash
   dotnet run
   ```
5. Follow the on-screen prompts to manage orders, prepare them, and view summaries.

## How to Use the Application
- **Main Menu:**  
  Choose between managing the Main Office, the Second Office, or viewing the total orders and revenue summary.
  
- **Bakery Office Menu:**  
  - **Add Order:**  
    - Select a bread type.
    - Enter the desired quantity (with validation against the office's remaining capacity).
    - Confirm or cancel the order.
  - **Prepare All Orders:**  
    - Simulate the bread preparation process and clear the order list for that office.
  
- **Summary View:**  
  Displays the historical total orders and revenue across all offices.

