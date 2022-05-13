using Flexbook.Data.Models.Users;

namespace Flexbook.Data.Models.ShoppingManagement
{
    public class Order
    {
        ICustomer Customer { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
