using backend.Data;
using backend.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly DataContext _context;

        public PostController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAllPostss()
        {
            var posts = await _context.Post.ToListAsync();

            return Ok(posts);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Post.FindAsync(id);
            if (post is null)
                return NotFound("post not found");
            return Ok(post);
        }
        [HttpPost]
        public async Task<ActionResult<Post>> AddUser(Post post)
        {
            _context.Post.Add(post);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
        }
        [HttpPut]
        public async Task<ActionResult<Post>> UpdatePost(Post post)
        {
            var updatedPost = await _context.Post.FindAsync(post.Id);
            if (updatedPost is null)
                return NotFound("post not found");
            updatedPost.comment = post.comment;
            updatedPost.userId = post.userId;
            updatedPost.rating = post.rating;
            updatedPost.courseId= post.courseId;
            await _context.SaveChangesAsync();
            return Ok(updatedPost);
        }
        [HttpDelete]
        public async Task<ActionResult<Post>> DeletePost(int id)
        {
            var post = await _context.Post.FindAsync(id);
            if (post is null)
                return NotFound("post not found");
            _context.Post.Remove(post);
            await _context.SaveChangesAsync();
            return Ok(post);
        }
        [HttpGet("course/{courseId}")]
        public async Task<ActionResult<List<Post>>> GetPostsByCourseId(int courseId)
        {
            var posts = await _context.Post
                .Where(p => p.courseId == courseId)
                .ToListAsync();

            return Ok(posts);
        }

        [HttpGet("made/{userId}")]
        public async Task<ActionResult<List<Post>>> GetPostsByUserId(int userId)
        {
            var posts = await _context.Post
                .Where(p => p.userId == userId)
                .ToListAsync();

            return Ok(posts);
        }

    }
}
