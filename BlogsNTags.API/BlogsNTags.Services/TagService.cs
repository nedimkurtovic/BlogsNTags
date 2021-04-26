using BlogsNTags.Services.Interfaces;
using BlogsNTags.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogsNTags.Services
{
    public class TagService : ITagService
    {
        public async Task<List<Tag>> GetTagsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
