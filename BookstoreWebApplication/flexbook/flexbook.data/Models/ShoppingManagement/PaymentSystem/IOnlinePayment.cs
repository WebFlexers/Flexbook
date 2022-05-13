using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexbook.Data.Models.ShoppingManagement.PaymentSystem
{
    public interface IOnlinePayment : IPayment
    {
        /// <summary>
        /// Processes the transaction and if it goes through
        /// returns true, otherwise false
        /// </summary>
        /// <returns></returns>
        public bool ProcessTransaction();
    }
}
