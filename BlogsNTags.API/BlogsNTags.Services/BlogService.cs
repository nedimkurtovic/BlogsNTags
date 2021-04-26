using BlogsNTags.Services.Interfaces;
using BlogsNTags.SharedModels;
using BlogsNTags.SharedModels.Requests.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogsNTags.Services
{
    public class BlogService : IBlogService
    {
        public async Task<Blog> AddBlogAsync(BlogCreateRequest obj)
        {
            throw new NotImplementedException();
        }

        public async Task<Blog> DeleteBlogAsync(string Slug)
        {
            throw new NotImplementedException();
        }

        public async Task<Blog> GetBlogAsync(string Slug)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Blog>> GetBlogsAsync(BlogSearchRequest obj)
        {
            throw new NotImplementedException();
        }

        public async Task<Blog> UpdateBlogAsync(string Slug, BlogUpdateRequest obj)
        {
            throw new NotImplementedException();
        }
    }
}
