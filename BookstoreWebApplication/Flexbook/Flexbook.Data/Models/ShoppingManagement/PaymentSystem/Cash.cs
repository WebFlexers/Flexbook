using Flexbook.Data.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexbook.Data.Models.ShoppingManagement.PaymentSystem
{
    public class Cash : IPayment
    {
        public IUser PayingUser { get; set; }
        public decimal Price { get; set; }
    }
}
