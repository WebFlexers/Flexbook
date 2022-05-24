using Flexbook.Data.Models.CustomExceptions;
using Flexbook.Data.Models.UserManagement;
using System.Diagnostics;

namespace Flexbook.Data.Models.ShoppingManagement.PaymentSystem
{
    public class CreditCard : IOnlinePayment, IDisposable
    {
        public CreditCard(char[] number, DateOnly expirationDate, char[] cvc)
        {
            _number = number;
            _expirationDate = expirationDate;
            _cvc = cvc;
        }

        // Credit card information
        private char[] _number;
        private DateOnly _expirationDate;
        private char[] _cvc;

        public decimal Price { get; set; }
        public IUser PayingUser { get; set; }

        public bool ProcessTransaction()
        {
            try
            {
                return IsCreditCardValid(this);
            }
            catch (InvalidCreditCardException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// <para> Sample method that checks the validity of the card </para>
        /// ATTENTION: This method will just check if the card
        /// information has the correct structure and not if
        /// it is an actual working card
        /// </summary>
        /// <param name="card"></param>
        /// <exception cref="InvalidCreditCardException"></exception>
        /// <returns></returns>
        public static bool IsCreditCardValid(CreditCard card)
        {
            if (card._number.Length != 16)
                throw new InvalidCreditCardException("The card number is not valid");

            if (card._expirationDate <= DateOnly.FromDateTime(DateTime.Now))
                throw new InvalidCreditCardException("The card is expired");

            if (card._cvc.Length != 3)
                throw new InvalidCreditCardException("The card cvc is not valid");

            return true;
        }

        #region Dispose logic

        private bool _disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~CreditCard()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
