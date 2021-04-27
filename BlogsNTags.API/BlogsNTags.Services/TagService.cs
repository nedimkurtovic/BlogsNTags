using AutoMapper;
using BlogsNTags.Database;
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
        private readonly MyDbContext db;
        private readonly IMapper mapper;

        public TagService(MyDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }
        public List<Tag> GetTags()
        {
            var TagList = db.Tags.ToList();
            return mapper.Map<List<SharedModels.Tag>>(TagList);
        }
    }
}
