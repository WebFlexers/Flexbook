namespace Flexbook.Data.Models.ShoppingManagement
{
    public interface IProduct
    {
        decimal FinalPrice { get; set; }
        int Id { get; set; }
        string Image { get; set; }
        decimal StartingPrice { get; set; }
        string Title { get; set; }
    }
}