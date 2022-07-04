using Flexbook.Data.Models.Users;
using Flexbook.Data.Models.Users.Components;
using Flexbook.Services;
using Microsoft.AspNetCore.Mvc;


namespace Flexbook.Web.Controllers;

[Route("api/customer")]
[ApiController]
public class CustomerController : Controller
{
    private readonly ILogger<CustomerController> _logger;
    private ICustomerService _customerService;

    public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
    {
        _customerService = customerService;
        _logger = logger;
    }

    [HttpGet("get/{id}")]
    public IActionResult GetCustomer(int id)
    {
        var customer = _customerService.GetById(id);
        return Ok(customer);
    }

    [HttpPost("register")]
    public IActionResult AddCustomer()
    {
        Customer customer = new Customer
        {
            Username = "lefterisk25",
            Password = "252525",
            Fullname = "Lefteris Kontouris",
            Email = "lefterisk00725@gmail.com",
            Address = new Address
            {
                Street = "Gymnastiriou O.T.",
                Number = 370,   
                City = "Megara",
                PostCode = "19100",
            },
            PhoneNumber = "6983701433",
            Image = "default.jpg",
            BirthDate = new DateTime(2001, 1, 25).ToUniversalTime(),
            Role = "Customer"
        };

        _customerService.Insert(customer);

        return Ok();
    }

    [HttpPost("delete/{id}")]
    public IActionResult RemoveCustomer(int id)
    {
        _customerService.Delete(_customerService.GetById(id));
        return Ok();
    }
}
