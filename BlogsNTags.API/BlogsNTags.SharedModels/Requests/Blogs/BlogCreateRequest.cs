using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogsNTags.SharedModels.Requests.Blogs
{
    public class BlogCreateRequest
    {
        [Required]
        public string? Title { get; set; }
        
        [Required]
        public string? Description { get; set; }
        
        [Required]
        public string? Body { get; set; }
        public List<string> TagList { get; set; } = new List<string>();
    }
}
