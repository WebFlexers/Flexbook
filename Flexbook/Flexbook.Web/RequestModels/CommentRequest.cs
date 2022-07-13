namespace Flexbook.Web.RequestModels
{
    public class CommentRequest
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public int AuthorHostId { get; set; }
    }
}
