using Microsoft.AspNetCore.Mvc;
using Flexbook.Services.Order;
using Flexbook.Web.RequestModels;
using Flexbook.Data.Models.OrderSystem;
using Flexbook.Services;
using Flexbook.Services.Books;
using Flexbook.Data.Models.Products;

namespace Flexbook.Web.Controllers;

[Route("api/customer/order")]
[ApiController]
public class OrderController : Controller
{
    private readonly ILogger<CustomerController> _logger;

    private IOrderService _orderService;
    private IOrderItemService _orderItemService;
    private ICustomerService _customerService;
    private IBookService _bookService;


    public OrderController(ILogger<CustomerController> logger, IOrderService orderService, ICustomerService customerService
        , IOrderItemService orderItemService, IBookService bookService)
    {
        _logger = logger;

        _orderService = orderService;
        _orderItemService = orderItemService;
        _customerService = customerService;
        _bookService = bookService;
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
        double tempTotalPrice = 0;
        var tempOrderItemsList = new List<OrderItem>();        
        foreach(var itemRequest in orderRequest.OrderItemsList)
        {
            OrderItem orderItem = new OrderItem
            {
                Quantity = itemRequest.Quantity,
                Product = _bookService.GetById(itemRequest.ProductId)
            };

            tempTotalPrice += (double) orderItem.Quantity * orderItem.Product.StartingPrice;

            tempOrderItemsList.Add(orderItem);
        }

        var now = DateTime.Now.ToUniversalTime();
        Order order = new Order()
        {
            CreatedOn = now,
            UpdatedOn = now,
            PaymentMethod = orderRequest.PaymentMethod,
            Items = tempOrderItemsList,
            Status = "Pending",
            TotalPrice = tempTotalPrice,
            Customer = _customerService.GetById(orderRequest.CustomerId)
        };

        _orderService.Insert(order);

        return Ok();
    }

    [HttpPost("remove_order")]
    public IActionResult RemoveOrder(int order_id)
    {
        _orderService.Delete(_orderService.GetById(order_id));

        return Ok();
    }


}
