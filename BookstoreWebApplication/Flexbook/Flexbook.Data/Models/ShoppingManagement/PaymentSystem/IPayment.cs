using Flexbook.Data.Models.UserManagement;

namespace Flexbook.Data.Models.ShoppingManagement.PaymentSystem
{
    public interface IPayment
    {
        IUser PayingUser { get; set; }
        decimal Price { get; set; }

    }
}
