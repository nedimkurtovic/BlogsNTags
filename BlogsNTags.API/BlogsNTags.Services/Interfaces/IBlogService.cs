using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogsNTags.Services.Interfaces
{
    public interface IBlogService
    {
        Task<List<BlogsNTags.SharedModels.Blog>> GetBlogsAsync(SharedModels.Requests.Blogs.BlogSearchRequest obj);
        Task<BlogsNTags.SharedModels.Blog> GetBlogAsync(string Slug);
        Task<BlogsNTags.SharedModels.Blog> AddBlogAsync(SharedModels.Requests.Blogs.BlogCreateRequest obj);
        Task<BlogsNTags.SharedModels.Blog> UpdateBlogAsync(string Slug, SharedModels.Requests.Blogs.BlogUpdateRequest obj);
        Task<BlogsNTags.SharedModels.Blog> DeleteBlogAsync(string Slug);

    }
}
