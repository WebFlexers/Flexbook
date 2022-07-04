using Flexbook.Data.Models.Users;
using Flexbook.Data.Models.Users.Components;
using Flexbook.Services;
using Flexbook.Web.RequestModels;
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
        _logger = logger;
        _customerService = customerService;
    }

    [HttpGet("get/{id}")]
    public IActionResult GetCustomer(int id)
    {
        var customer = _customerService.GetById(id);
        return Ok(customer);
    }

    [HttpPost("register")]
    public IActionResult AddCustomer([FromBody] CustomerRequest customerRequest)
    {
        Customer customer = new Customer
        {
            Username = customerRequest.Username,
            Password = customerRequest.Password,
            Fullname = customerRequest.Fullname,
            Email = customerRequest.Email,
            Address = new Address
            {
                Street = customerRequest.Address.Street,
                Number = customerRequest.Address.Number,
                City = customerRequest.Address.City,
                PostCode = customerRequest.Address.PostCode,
            },
            PhoneNumber = customerRequest.PhoneNumber,
            Image = customerRequest.Image,
            BirthDate = customerRequest.BirthDate,
            Role = customerRequest.Role
        };

        if (ModelState.IsValid)
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
