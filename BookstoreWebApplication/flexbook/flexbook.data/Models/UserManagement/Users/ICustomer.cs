using Flexbook.Data.Models.UserManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flexbook.Data.Models.Users
{
    public interface ICustomer : IRegisterableUser
    {
        Address Address { get; set; }
        DateTime BirthDate { get; set; }
        string LandlineNumber { get; set; }
        string MobilePhoneNumber { get; set; }
        Email Email { get; set; }
        ShoppingCart ShoppingCart { get; set; }
        
        void MakeOrder(Order order);
    }
}
