using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogsNTags.SharedModels
{
    public class Blog:BaseEntity
    {
        public string Slug { get; set; } = String.Empty;
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Body { get; set; } = String.Empty;

        public List<Tag> TagList { get; set; } = new List<Tag>();
        
    }
}
