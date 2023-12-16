using System.Collections.Generic;
using OrderApi.Model;

namespace OrderApi.DAL
{
    public static class InMemoryDatabase
    {
        public static List<Orders> Orders { get; } = new List<Orders>
        {
            new Orders { Id = 1, ProductName = "Cheeseburger", Price = 5, Category = "Food" },
            new Orders { Id = 2, ProductName = "Pepperoni Pizza", Price = 10, Category = "Food" },
            new Orders { Id = 3, ProductName = "Veggie Wrap", Price = 7, Category = "Food" },
            new Orders { Id = 4, ProductName = "Chicken Salad", Price = 8, Category = "Food" },
            new Orders { Id = 5, ProductName = "Soda", Price = 2, Category = "Beverage" },
            new Orders { Id = 6, ProductName = "Chips", Price = 3, Category = "Snack" },
            new Orders { Id = 7, ProductName = "Chocolate Bar", Price = 2, Category = "Snack" },
            new Orders { Id = 8, ProductName = "Laptop Bag", Price = 25, Category = "Other" },
            new Orders { Id = 9, ProductName = "Notebook", Price = 3, Category = "Other" },
            new Orders { Id = 10, ProductName = "Pen Set", Price = 5, Category = "Other" }
        };
    }
}
