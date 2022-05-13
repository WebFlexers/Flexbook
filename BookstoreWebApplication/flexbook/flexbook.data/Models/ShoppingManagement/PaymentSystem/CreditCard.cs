namespace Flexbook.Data.Models.ShoppingManagement.PaymentSystem
{
    public class CreditCard : IOnlinePayment, IDisposable
    {
        public string Owner { get; set; }

        public CreditCard(string owner, char[] number, DateOnly expirationDate, string cvc)
        {
            Owner = owner;
            _number = number;
            _expirationDate = expirationDate;
            _cvc = cvc;
        }

        private char[] _number;
        private DateOnly _expirationDate;
        private string _cvc;
        private bool _disposedValue;

        public decimal Price { get; set; }

        public bool ProcessTransaction()
        {
            return true;
        }

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
    }
}
