namespace Flexbook.Web.RequestModels
{
    public class CommentRequest
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int LikesCount { get; set; }
        public int User_Id { get; set; }
    }
}
