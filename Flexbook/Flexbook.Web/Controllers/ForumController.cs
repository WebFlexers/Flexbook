using Flexbook.Data.Models.Users;
using Flexbook.Data.Models;
using Flexbook.Services;
using Flexbook.Web.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace Flexbook.Web.Controllers;

[Route("api/author/{username}/forum")]
[ApiController]
public class ForumController : Controller
{
    private string username = "default";

    private CrudService<Customer> _customerService;
    private CrudService<Author> _authorService;
    private CrudService<Comment> _commentService;

    public ForumController()
    {
        _customerService = new CrudService<Customer>();
        _authorService = new CrudService<Author>();
        _commentService = new CrudService<Comment>();
    }

    [HttpPost("add_comment")]
    public IActionResult AddComment([FromBody] CommentRequest commentRequest)
    {
        Comment comment = new Comment
        {
            Content = commentRequest.Content,
            CreatedOn = DateTime.Now,
            UpdatedOn = DateTime.Now,
            LikesCount = 0,
            User = _customerService.GetById(commentRequest.UserId),
            AuthorHost = _authorService.GetById(commentRequest.AuthorHostId),
        };

        _commentService.Insert(comment);

        return Ok();
    }

    [HttpPost("edit_comment")]
    public IActionResult ShowAllComments(int author_id)
    {

        
        return Ok();
    }
}
