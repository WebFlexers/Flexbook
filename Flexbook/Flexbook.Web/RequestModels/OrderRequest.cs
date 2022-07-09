namespace Flexbook.Web.RequestModels
{
    public class OrderRequest
    {
        public string PaymentMethod { get; set; }
        public List<OrderItemRequest> OrderItemsList { get; set; }
        public int CustomerId { get; set; }
    }
}
