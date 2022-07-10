using Flexbook.Data.Models.Users;
using Flexbook.Data.Models;
using Flexbook.Services;
using Flexbook.Web.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Flexbook.Services.AuthorForum;
using Flexbook.Services.Users.User;

namespace Flexbook.Web.Controllers;

[Route("api/author/forum")]
[ApiController]
public class ForumController : Controller
{
    private readonly ILogger<CustomerController> _logger;

    private ICommentService _commentService;
    private IUserService _userService;
    private IAuthorService _authorService;

    public ForumController(ILogger<CustomerController> logger, ICommentService commentService, IUserService userService, IAuthorService authorService)
    {
        _logger = logger;

        _commentService = commentService;
        _userService = userService;
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
        var dateTimeNow = DateTime.Now.ToUniversalTime();

        Comment comment = new Comment
        {
            Content = commentRequest.Content,
            CreatedOn = dateTimeNow,
            UpdatedOn = dateTimeNow,
            LikesCount = 0,
            User = _userService.GetById(commentRequest.UserId),
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
        _commentService.Delete(_commentService.GetById(comment_id));

        return Ok();
    }
}
