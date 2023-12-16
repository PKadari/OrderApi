using OrderApi.Model;
using System.Collections.Generic;

namespace OrderApi.Services
{
    public interface IResourceService
    {
        IEnumerable<Orders> GetOrders(int page, int pageSize);
        Orders GetOrderById(int orderId);
        void PlaceOrder(Orders order);
    }
}
