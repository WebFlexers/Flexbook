using Flexbook.Data.DataAccess;
using Flexbook.Data.Models.Products;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Flexbook.Services.Order;

public class OrderService : CrudService<Data.Models.OrderSystem.Order>, IOrderService
{
    public OrderService(FlexbookDbContext dbContext) : base(dbContext) { }

    [return: MaybeNull]
    public override Data.Models.OrderSystem.Order? GetById(int id)
    {
        return _dbContext.Set<Data.Models.OrderSystem.Order>()
            .Include(order => order.Items)
            .ThenInclude(item => item.Product)
            .Include(order => order.Customer)
            .FirstOrDefault(order => order.Id == id);
    }

    public List<Data.Models.OrderSystem.Order> GetAllOrdersByAuhorId(int author_id)
    {
        return _dbContext.Set<Data.Models.OrderSystem.Order>()
            .Include(order => order.Items
                .Select(items => (Book)items.Product)
                .Where(book => book.Author.Id == author_id))
            .ToList();         
    }
}
