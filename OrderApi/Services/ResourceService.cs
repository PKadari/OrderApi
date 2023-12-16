using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using OrderApi.DAL;
using OrderApi.Model;

namespace OrderApi.Services
{
    public class ResourceService : IResourceService
    {
        private readonly ILogger<ResourceService> _logger;

        public ResourceService(ILogger<ResourceService> logger)
        {
            _logger = logger;
        }

        public IEnumerable<Orders> GetOrders(int page, int pageSize)
        {
            try
            {
                return InMemoryDatabase.Orders.Skip((page - 1) * pageSize).Take(pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching orders.");
                throw;
            }
        }

        public Orders GetOrderById(int orderId)
        {
            return InMemoryDatabase.Orders.FirstOrDefault(o => o.Id == orderId);
        }

        public void PlaceOrder(Orders order)
        {
            try
            {
                // Implement logic for placing an order
                order.Id = InMemoryDatabase.Orders.Count + 1; // Assign a new ID
                InMemoryDatabase.Orders.Add(order);
                _logger.LogInformation($"Order placed successfully. OrderId: {order.Id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error placing order.");
                throw;
            }
        }
    }
}
