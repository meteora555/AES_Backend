using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AES.Client.ViewModels.Requests;
using AES.DAL.Context;
using AES.DAL.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AES.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly DefaultDbContext _context;

        public PostsController(DefaultDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("createPost")]
        [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request)
        {
            var post = new Post()
            {
                Id = Guid.NewGuid(),
                Text = request.Text,
                Title = request.Title
            };
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return Ok(post);
        }
    }
}
