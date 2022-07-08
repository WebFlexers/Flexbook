using Flexbook.Data.DataAccess;
using Flexbook.Data.Models.OrderSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexbook.Services.Order
{
    public class OrderItemService : CrudService<OrderItem>, IOrderItemService
    {
        public OrderItemService(FlexbookDbContext dbContext) : base(dbContext) { }
    }
}
