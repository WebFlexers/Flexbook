using Flexbook.Data.Models.Users;

namespace Flexbook.Data.Models.ShoppingManagement
{
    public class Order
    {
        public Customer Customer { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
