using Flexbook.Data.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexbook.Data.Models.ShoppingManagement.PaymentSystem
{
    public class Cryptocurrency : IOnlinePayment
    {    
        public IUser PayingUser { get; set; }
        public decimal Price { get; set; }

        private char[] _address;
        private IBlockchainNetwork _network;

        public Cryptocurrency(char[] address, IBlockchainNetwork network)
        {
            _address = address;
            _network = network;
        }

        public bool ProcessTransaction()
        {
            return _network.Send(_address);
        }

        #region Dispose Logic

        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Cryptocurrency()
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
