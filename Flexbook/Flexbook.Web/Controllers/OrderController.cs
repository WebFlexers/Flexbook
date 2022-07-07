using Microsoft.AspNetCore.Mvc;
using Flexbook.Services.Order;
using Flexbook.Web.RequestModels;
using Flexbook.Data.Models.OrderSystem;
using Flexbook.Services;

namespace Flexbook.Web.Controllers;

[Route("api/customer/order")]
[ApiController]
public class OrderController : Controller
{
    private readonly ILogger<CustomerController> _logger;

    private IOrderService _orderService;
    private ICustomerService _customerService;


    public OrderController(ILogger<CustomerController> logger, IOrderService orderService, ICustomerService customerService)
    {
        _logger = logger;

        _orderService = orderService;
        _customerService = customerService;
    }

    [HttpGet("get_order")]
    public IActionResult GetOrder(int orderId)
    {
        var order = _orderService.GetById(orderId);
        return Ok(order);
    }

    [HttpPost("place_order")]
    public IActionResult PlaceOrder([FromBody] OrderRequest orderRequest)
    {
        Order order = new Order()
        {
            CreatedOn = orderRequest.CreatedOn,
            UpdatedOn = orderRequest.UpdatedOn,
            PaymentMethod = orderRequest.PaymentMethod,
            Items = orderRequest.Items,
            Status = orderRequest.Status,
            TotalPrice = orderRequest.TotalPrice,
            Customer = _customerService.GetById(orderRequest.CustomerId)
        };

        return Ok();
    }

}
