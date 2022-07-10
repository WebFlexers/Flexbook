using Flexbook.Data.Models.OrderSystem;

namespace Flexbook.Services.Order;

public interface IOrderService : ICrudService<Data.Models.OrderSystem.Order>
{
    public List<Data.Models.OrderSystem.Order> GetAllOrdersByAuhorId(int author_id);
}
