using Flexbook.Data.DataAccess;
using Flexbook.Data.Models.OrderSystem;
using Flexbook.Data.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace Flexbook.Services.Order
{
    public class OrderItemService : CrudService<OrderItem>, IOrderItemService
    {
        public OrderItemService(FlexbookDbContext dbContext) : base(dbContext) { }
        public List<OrderItem> GetAllOrderItems()
        {
            return _dbContext.Set<OrderItem>()
                .Include(product => product.Product)
                .ToList();
        }
    }
}