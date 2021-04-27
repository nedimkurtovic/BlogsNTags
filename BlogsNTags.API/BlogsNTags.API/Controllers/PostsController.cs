using BlogsNTags.Services.Interfaces;
using BlogsNTags.SharedModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using BlogsNTags.SharedModels.Requests.Blogs;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace BlogsNTags.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IBlogService blogService;

        public PostsController(IBlogService _blogService)
        {
            blogService = _blogService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task< ActionResult<List<Blog>>> GetBlogs([FromQuery]BlogSearchRequest obj)
        {
            var result = await blogService.GetBlogsAsync(obj);
            return Ok(result);
        }

        [HttpGet("{slug}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Blog>> GetBlog(string slug)
        {
            var result = await blogService.GetBlogAsync(slug);
            if (result == default(Blog))
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Blog>> CreateBlog([FromBody] BlogCreateRequest obj)
        {
            var result = await blogService.AddBlogAsync(obj);
            return CreatedAtAction(nameof(GetBlog),new { slug=result.Slug }, result);
        }
        
        [HttpPut("{slug}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Blog> CreateBlog(string slug, [FromBody] BlogUpdateRequest obj)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{slug}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Blog> DeleteBlog(string slug)
        {
            throw new NotImplementedException();
        }
    }
}
