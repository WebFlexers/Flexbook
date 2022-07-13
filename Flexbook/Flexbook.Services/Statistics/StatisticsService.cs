using Flexbook.Data.DataAccess;
using Flexbook.Data.Models.Products;
using Flexbook.Services.Order;

namespace Flexbook.Services.Statistics;

public class StatisticsService : IStatisticsService
{
    private readonly FlexbookDbContext _dbContext;

    private IOrderService _orderService;

    public StatisticsService(FlexbookDbContext dbContext)
    {
        _dbContext = dbContext;

        _orderService = new OrderService(dbContext);
    }

    public List<Data.Models.OrderSystem.Order> GetAllOrdersByAuthorId(int author_id)
    {
        // return _orderService.GetAllOrdersByAuhorId(author_id);
        throw new NotImplementedException();
    }

    public Book GetBestSellerBookOfAuthor(int author_id)
    {
        throw new NotImplementedException();
    }
}
