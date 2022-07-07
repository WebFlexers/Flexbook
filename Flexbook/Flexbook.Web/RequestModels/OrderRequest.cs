namespace Flexbook.Web.RequestModels
{
    public class OrderRequest
    {
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string PaymentMethod { get; set; }
        public List<OrderItemRequest> Items { get; set; }
        public string Status { get; set; }
        public double TotalPrice { get; set; }
        public int CustomerId { get; set; }
    }
}
