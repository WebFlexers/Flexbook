namespace Flexbook.Data.Models.ShoppingManagement.PaymentSystem
{
    public interface IOnlinePayment : IPayment, IDisposable
    {
        /// <summary>
        /// Processes the transaction and if it goes through
        /// returns true, otherwise false
        /// </summary>
        /// <returns></returns>
        public bool ProcessTransaction();
    }
}
