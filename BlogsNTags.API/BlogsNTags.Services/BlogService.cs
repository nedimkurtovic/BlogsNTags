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
            //ValidateAdd(obj); when business logic arises, call method to validate
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
            return MapBlogWithTags(newblog);

        }

        public async Task<Blog> DeleteBlogAsync(string Slug)
        {
            var dbObject = await GetDatabaseBlogBySlug(Slug);
            if (dbObject == default(Database.Models.Blog))
                return default(SharedModels.Blog);

            var returnObject = MapBlogWithTags(dbObject);
            db.Blogs.Remove(dbObject);
            await db.SaveChangesAsync();

            return returnObject;
        }

        public async Task<Blog> GetBlogAsync(string Slug)
        {
            var result = await GetDatabaseBlogBySlug(Slug);  
            if (result == default(Database.Models.Blog))
                return default(SharedModels.Blog);

            return MapBlogWithTags(result);      
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
                var ConvertedBlog = MapBlogWithTags(dbBlog);
                returnObjectBlogs.Add(ConvertedBlog);
            }

            return returnObjectBlogs;
            
        }

        public async Task<Blog> UpdateBlogAsync(string Slug, BlogUpdateRequest obj)
        {
            //ValidateUpdate(obj); when business logic arises, call method to validate

            var databaseBlog = await GetDatabaseBlogBySlug(Slug);
            if (databaseBlog == default(Database.Models.Blog))
                return default(SharedModels.Blog);

            if (obj.Title != null)
            {
                databaseBlog.Title = obj.Title;
                var newSlug = CreateUniqueSlug(obj.Title);
                databaseBlog.Slug = newSlug;
            }

            if (obj.Description != null)
                databaseBlog.Description = obj.Description;
            if (obj.Body != null)
                databaseBlog.Body = obj.Body;

            db.Blogs.Update(databaseBlog);
            db.SaveChanges();

            return MapBlogWithTags(databaseBlog);
        }

        #region Validacija
        
        //private bool ValidateAdd(BlogCreateRequest obj)
        //{
        //    //for now its true, any further validation rules can be added here
        //    return true;
        //}

        //private bool ValidateUpdate(BlogUpdateRequest obj)
        //{
        //    //for now its true, any further validation rules can be added here
        //    return true;
        //}

        #endregion

        #region Helpers
        private SharedModels.Blog MapBlogWithTags(Database.Models.Blog obj)
        {
            var ReturnObject = mapper.Map<SharedModels.Blog>(obj);
            foreach (var tag in obj.BlogsTags)
                ReturnObject.TagList.Add(mapper.Map<SharedModels.Tag>(tag.Tag));
            return ReturnObject;
        }
        private async Task<Database.Models.Blog> GetDatabaseBlogBySlug(string Slug)
        {
            return await db.Blogs
               .AsNoTracking()
               .Include(x => x.BlogsTags)
                   .ThenInclude(x => x.Tag)
               .Where(x => x.Slug == Slug).FirstOrDefaultAsync();
            
        }
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
