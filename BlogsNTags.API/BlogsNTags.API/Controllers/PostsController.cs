﻿using BlogsNTags.Services.Interfaces;
using BlogsNTags.SharedModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using BlogsNTags.SharedModels.Requests.Blogs;
using System.Linq;
using System.Threading.Tasks;

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
        public ActionResult<List<Blog>> GetBlogs([FromQuery]BlogSearchRequest obj)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{slug}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Blog> GetBlog(string slug)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Blog> CreateBlog([FromBody] BlogCreateRequest obj)
        {
            throw new NotImplementedException();
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