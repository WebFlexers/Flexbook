using Flexbook.Data.Models.Users;
using Flexbook.Data.Models;
using Flexbook.Services;
using Flexbook.Web.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Flexbook.Services.AuthorForum;

namespace Flexbook.Web.Controllers;

[Route("api/author/forum")]
[ApiController]
public class ForumController : Controller
{
    private readonly ILogger<CustomerController> _logger;

    private ICommentService _commentService;
    private ICustomerService _customerService;
    private IAuthorService _authorService;

    public ForumController(ILogger<CustomerController> logger, ICommentService commentService, ICustomerService customerService, IAuthorService authorService)
    {
        _logger = logger;

        _commentService = commentService;
        _customerService = customerService;
        _authorService = authorService;
    }

    [HttpGet("get_comment")]
    public IActionResult GetComment(int comment_id)
    {
        var comment = _commentService.GetById(comment_id);

        return Ok(comment);
    }

    [HttpPost("add_comment")]
    public IActionResult AddComment([FromBody] CommentRequest commentRequest)
    {
        Comment comment = new Comment
        {
            Content = commentRequest.Content,
            CreatedOn = commentRequest.CreatedOn,
            UpdatedOn = commentRequest.UpdatedOn,
            LikesCount = 0,
            User = _customerService.GetById(commentRequest.UserId),
            AuthorHost = _authorService.GetById(commentRequest.AuthorHostId),
        };

        if (ModelState.IsValid)
            _commentService.Insert(comment);

        return Ok();
    }

    [HttpPost("all_comments")]
    public IActionResult ShowAllCommentsByAuthor(int author_id)
    {
        var all_comments = _commentService.GetAllCommentsByAuthor(author_id);
        
        return Ok(all_comments);
    }

    [HttpPost("like")]
    public IActionResult LikeComment(int comment_id)
    {
        _commentService.AddLikeToComment(comment_id);

        return Ok();
    }

    [HttpPost("remove_comment")]
    public IActionResult RemoveComment(int comment_id)
    {
        var comment = _commentService.GetById(comment_id);
        _commentService.Delete(comment);

        return Ok();
    }
}
