using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderApi.Model;
using OrderApi.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IResourceService _resourceService;

        public OrderController(ILogger<OrderController> logger, IResourceService resourceService)
        {
            _logger = logger;
            _resourceService = resourceService;
        }

        [HttpGet]
        public IActionResult GetOrders(int page = 1, int pageSize = 10)
        {
            try
            {
                var orders = _resourceService.GetOrders(page, pageSize);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching orders");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrderById(int orderId)
        {
            try
            {
                var order = _resourceService.GetOrderById(orderId);

                if (order == null)
                {
                    return NotFound($"Order with Id {orderId} not found");
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching order with Id {orderId}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public IActionResult PlaceOrder([FromBody] Orders orders)
        {
            try
            {
                var validationContext = new ValidationContext(orders, serviceProvider: null, items: null);
                Validator.ValidateObject(orders, validationContext, validateAllProperties: true);

                var order = new Orders
                {
                    ProductName = orders.ProductName,
                    Price = orders.Price,
                    Category = orders.Category
                };

                _resourceService.PlaceOrder(order);

                _logger.LogInformation("Order placed successfully.");

                return Ok();
            }
            catch (ValidationException ex)
            {
                _logger.LogError(ex, "Validation error placing order");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error placing order");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
