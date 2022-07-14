using Flexbook.Data.DataAccess;
using Flexbook.Data.Models.Products;
using Flexbook.Services.Books;
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

    /// <summary>
    /// Gets 
    /// </summary>
    /// <param name="author"></param>
    /// <returns></returns>
    public Dictionary<int, int> GetBooksSalesOfAuthor(int authorId)
    {
        var booksSales = new Dictionary<int, int>();
        
        var orderItemService = new OrderItemService(_dbContext);
        var bookService = new BookService(_dbContext);

        var booksByAuthor = bookService.GetAllByAuthor(authorId);
        var orderItems = orderItemService.GetAllOrderItems();

        foreach (var book in booksByAuthor)
        {
            foreach (var orderItem in orderItems)
            {
                if (book.Id == orderItem.Product.Id)
                {
                    if (booksSales.ContainsKey(book.Id))
                    {
                        booksSales[book.Id] += orderItem.Quantity;
                    }
                    else
                    {
                        booksSales.Add(book.Id, orderItem.Quantity);
                    }
                }
            }
        }

        return booksSales;
    }
}
