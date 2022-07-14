using Flexbook.Services.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace Flexbook.Web.Controllers;

[Route("api/author/statistics")]
[ApiController]
public class StatisticsController : Controller
{
    private readonly ILogger<StatisticsController> _logger;

    private IStatisticsService _statisticsService;

    public StatisticsController(ILogger<StatisticsController> logger, IStatisticsService statisticsService)
    {
        _logger = logger;
        _statisticsService = statisticsService;
    }

    [HttpGet("get_book_sales/{authorId}")]
    public IActionResult GetBooksSalesByAuthorId(int authorId)
    {
        var booksSales = _statisticsService.GetBooksSalesOfAuthor(authorId);
        return Ok(booksSales);
    }
}
