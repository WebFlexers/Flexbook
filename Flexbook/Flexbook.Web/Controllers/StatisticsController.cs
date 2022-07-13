using Flexbook.Services.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace Flexbook.Web.Controllers;

[Route("api/author/statistics")]
[ApiController]
public class StatisticsController : Controller
{
    private readonly ILogger<CustomerController> _logger;

    private IStatisticsService _statisticsService;

    public StatisticsController(ILogger<CustomerController> logger, IStatisticsService statisticsService)
    {
        _logger = logger;

        _statisticsService = statisticsService;
    }

    [HttpGet("get_all_orders")]
    public IActionResult GetAllOrdersByAuthor(int author_id)
    {
        var tempOrders = _statisticsService.GetAllOrdersByAuthorId(author_id);

        return Ok(tempOrders);
    }

}
