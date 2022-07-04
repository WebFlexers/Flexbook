namespace Flexbook.Web.RequestModels
{
    public class BookReviewRequest
    {
        public int Rating { get; set; }
        public string Content { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
    }
}
