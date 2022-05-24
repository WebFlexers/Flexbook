namespace Flexbook.Data.Models.ShoppingManagement.PaymentSystem
{
    public interface IBlockchainNetwork
    {
        bool Send(char[] address);
    }
}
