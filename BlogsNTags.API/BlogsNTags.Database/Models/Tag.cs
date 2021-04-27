using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogsNTags.Database.Models
{
    public class Tag: BaseObject
    {
        [Required]
        public string Name { get; set; }
        public IList<BlogsTags> BlogsTags{ get; set; } = new List<BlogsTags>();
    }
}
