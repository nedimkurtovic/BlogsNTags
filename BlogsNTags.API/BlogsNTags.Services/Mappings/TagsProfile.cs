using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogsNTags.Services.Mappings
{
    public class TagsProfile:Profile
    {
        public TagsProfile()
        {
            CreateMap<Database.Models.Tag, SharedModels.Tag>();
        }
        
    }
}
