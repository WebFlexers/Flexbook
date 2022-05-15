using Flexbook.Data.Models.ShoppingManagement;
using Flexbook.Data.Models.UserManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flexbook.Data.Models.Users
{
    public class Customer : UserBase
    {
        [Required]
        public Address Address { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [MaxLength(10)]
        public string LandlineNumber { get; set; }
        [MaxLength(10)]
        public string MobilePhoneNumber { get; set; }

        [MaxLength(100)]
        public Email Email { get; set; }

        [NotMapped]
        public IShoppingCart? ShoppingCart { get; set; }


        public override void Login()
        {
            throw new NotImplementedException();
        }

        public override void Logout()
        {
            throw new NotImplementedException();
        }

        public Order MakeOrder(IShoppingCart shoppingCart)
        {
            return shoppingCart.CreateOrder();
        }

        public void Register()
        {
            throw new NotImplementedException();
        }
    }
}
