using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogsNTags.Services.Interfaces
{
    public interface ITagService
    {
        List<BlogsNTags.SharedModels.Tag> GetTags();
    }
}
