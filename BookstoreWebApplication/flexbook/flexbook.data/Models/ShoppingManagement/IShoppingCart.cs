namespace Flexbook.Data.Models.ShoppingManagement
{
    public interface IShoppingCart
    {
        List<OrderItem> OrderItems { get; set; }
        Order CreateOrder();
    }
}
