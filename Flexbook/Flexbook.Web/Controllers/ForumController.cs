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
    private readonly ILogger<ForumController> _logger;

    private ICommentService _commentService;
    private IUserService _userService;
    private IAuthorService _authorService;

    public ForumController(ILogger<ForumController> logger, ICommentService commentService, IUserService userService, IAuthorService authorService)
    {
        _logger = logger;

        _commentService = commentService;
        _userService = userService;
        _authorService = authorService;
    }

    [HttpGet("get_comment/{commentId}")]
    public IActionResult GetComment(int commentId)
    {
        var comment = _commentService.GetById(commentId);
        return Ok(comment);
    }

    [HttpPost("add_comment")]
    public IActionResult AddComment([FromBody] CommentRequest commentRequest)
    {
        var now = DateTime.Now.ToUniversalTime();
        
        Comment comment = new Comment
        {
            Content = commentRequest.Content,
            CreatedOn = now,
            UpdatedOn = now,
            LikesCount = 0,
            User = _userService.GetById(commentRequest.UserId),
            AuthorHost = _authorService.GetById(commentRequest.AuthorHostId),
        };

        if (ModelState.IsValid)
            _commentService.Insert(comment);

        return Ok();
    }

    [HttpGet("all_comments/{authorId}")]
    public IActionResult GetAllCommentsByAuthor(int authorId)
    {
        var allComments = _commentService.GetAllCommentsByAuthor(authorId);
        return Ok(allComments);
    }

    [HttpPost("like/{commentId}")]
    public IActionResult LikeComment(int commentId)
    {
        _commentService.AddLikeToComment(commentId);

        return Ok();
    }

    [HttpPost("remove_comment/{commentId}")]
    public IActionResult RemoveComment(int commentId)
    {
        _commentService.Delete(_commentService.GetById(commentId));

        return Ok();
    }
}
