using Flexbook.Data.DataAccess;
using Flexbook.Data.Models.Products;
using Flexbook.Services.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        return _orderService.GetAllOrdersByAuhorId(author_id);
    }

    public Book GetBestSellerBookOfAuthor(int author_id)
    {
        throw new NotImplementedException();
    }
}
