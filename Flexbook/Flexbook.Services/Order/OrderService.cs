using Flexbook.Data.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Flexbook.Services.Order;

public class OrderService : CrudService<Data.Models.OrderSystem.Order>, IOrderService
{
    public OrderService(FlexbookDbContext dbContext) : base(dbContext) { }
}
