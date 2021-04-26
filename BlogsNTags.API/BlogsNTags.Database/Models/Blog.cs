using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogsNTags.Database.Models
{
    public class Blog: BaseObject
    {
        [Required]
        public string Slug { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Body { get; set; }
        public IList<BlogsTags> BlogsTags { get; set; }
    }
}
