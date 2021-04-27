using AutoMapper;
using BlogsNTags.Database;
using BlogsNTags.Services.Interfaces;
using BlogsNTags.SharedModels;
using BlogsNTags.SharedModels.Requests.Blogs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlogsNTags.Services
{
    public class BlogService : IBlogService
    {
        private readonly MyDbContext db;
        private readonly IMapper mapper;

        public BlogService(MyDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }
        public async Task<Blog> AddBlogAsync(BlogCreateRequest obj)
        {
            await ValidateAdd(obj);
            var slug = CreateUniqueSlug(obj.Title);
            var newblog = mapper.Map<Database.Models.Blog>(obj);
            newblog.Slug = slug;
            db.Blogs.Add(newblog);
            db.SaveChanges();

            foreach (var tag in obj.TagList)
            {
                var TagObj = db.Tags.Where(x => x.Name == tag).FirstOrDefault();

                if(TagObj == default(Database.Models.Tag))
                {
                    TagObj = new Database.Models.Tag { Name = tag };
                    db.Tags.Add(TagObj);
                    db.SaveChanges();
                }

                newblog.BlogsTags.Add(new Database.Models.BlogsTags
                {
                    Blog = newblog,
                    Tag = TagObj
                });

            }
                    
            await db.SaveChangesAsync();
            var ReturnObject = mapper.Map<SharedModels.Blog>(newblog);
            foreach(var tag in newblog.BlogsTags)
                ReturnObject.TagList.Add(mapper.Map<SharedModels.Tag>(tag.Tag));

            return ReturnObject;

        }

        public async Task<Blog> DeleteBlogAsync(string Slug)
        {
            throw new NotImplementedException();
        }

        public async Task<Blog> GetBlogAsync(string Slug)
        {
            var result = await db.Blogs
                .AsNoTracking()
                .Include(x=>x.BlogsTags)
                    .ThenInclude(x=>x.Tag)
                .Where(x => x.Slug == Slug).FirstOrDefaultAsync();
            if (result == default(Database.Models.Blog))
                return default(SharedModels.Blog);

            var returnObject = mapper.Map<Blog>(result);
            foreach (var i in result.BlogsTags)
                returnObject.TagList.Add(mapper.Map<SharedModels.Tag>(i.Tag));

            return returnObject;
            
        }

        public async Task<List<Blog>> GetBlogsAsync(BlogSearchRequest obj)
        {
            var blogsQueryable= db.Blogs
                .AsNoTracking()
                .Include(x=>x.BlogsTags)
                    .ThenInclude(x=>x.Tag)
                .OrderByDescending(x=>x.CreatedAt)
                .AsQueryable();
            if (obj.Tag != null && !String.IsNullOrEmpty(obj.Tag))
                blogsQueryable = blogsQueryable.Where(x => x.BlogsTags.Select(c => c.Tag.Name).Contains(obj.Tag));
            
            var listOfBlogs = await blogsQueryable.ToListAsync();
            
            var returnObjectBlogs = new List<Blog>();
            foreach(var dbBlog in listOfBlogs)
            {
                var ConvertedBlog = mapper.Map<Blog>(dbBlog);
                foreach (var BlogsTags in dbBlog.BlogsTags)
                    ConvertedBlog.TagList.Add(mapper.Map<SharedModels.Tag>(BlogsTags.Tag));

                returnObjectBlogs.Add(ConvertedBlog);
            }

            return returnObjectBlogs;
            
        }

        public async Task<Blog> UpdateBlogAsync(string Slug, BlogUpdateRequest obj)
        {
            throw new NotImplementedException();
        }

        #region Validacija
        
        private async Task<bool> ValidateAdd(BlogCreateRequest obj)
        {
            return true;
        }



        #endregion

        #region Helpers
        private string CreateUniqueSlug(string Title)
        {
            var pattern = @"[àáâäæãåāăąçćčđďèéêëēėęěğǵḧîïíīįìłḿñńǹňôöòóœøōõőṕŕřßśšşșťțûüùúūǘůűųẃẍÿýžźż·_,:;]";
            var replacementArray = "aaaaaaaaaacccddeeeeeeeegghiiiiiilmnnnnoooooooooprrsssssttuuuuuuuuuwxyyzzz-------";

            string lowerC = Title.ToLower();
            var regex = new Regex(pattern);
            var regResult = Regex.Replace(lowerC, @"\s+", "-");
            regResult = regex.Replace(regResult, x =>
            {
                var i = pattern.IndexOf(regResult[x.Index]) - 1; // -1 because of [ at the beggining of pattern string
                if (i == -1)
                    return "-";
                return replacementArray[i - 1].ToString();
            });
            regResult = Regex.Replace(regResult, @"&", "and");
            regResult = Regex.Replace(regResult, @"[^\w\-]", "");
            regResult = Regex.Replace(regResult, @"\-\-+", "-"); // trim multiple - to one
            regResult = Regex.Replace(regResult, @"^\-+", ""); // trim - from start
            regResult = Regex.Replace(regResult, @"\-+$", ""); // trim - from end 

            bool unique = false;
            var SlugList = db.Blogs.AsNoTracking().Select(x => x.Slug).ToList();
            if (!SlugList.Contains(regResult))
                unique = true;
            while (!unique)
            {
                regResult = regResult + "-" + Guid.NewGuid().ToString().Substring(0, 8);
                if (!SlugList.Contains(regResult))
                    unique = true;
            }
            return regResult;
        }
        #endregion
    }
}
