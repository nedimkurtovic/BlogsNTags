using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogsNTags.Services.Mappings
{
    public class BlogsProfile: Profile
    {
        public BlogsProfile()
        {
            CreateMap<Database.Models.Blog, SharedModels.Blog>();
            CreateMap<SharedModels.Requests.Blogs.BlogCreateRequest, Database.Models.Blog>();
        }
    }
}
