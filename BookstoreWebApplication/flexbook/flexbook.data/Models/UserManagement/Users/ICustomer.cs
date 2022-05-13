using Flexbook.Data.Models.ShoppingManagement;
using Flexbook.Data.Models.UserManagement;

namespace Flexbook.Data.Models.Users
{
    public interface ICustomer : IRegisterableUser
    {
        Address Address { get; set; }
        DateTime BirthDate { get; set; }
        string LandlineNumber { get; set; }
        string MobilePhoneNumber { get; set; }
        Email Email { get; set; }
        IShoppingCart ShoppingCart { get; set; }
        
        Order MakeOrder(IShoppingCart shoppingCart);
    }
}
