using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogsNTags.SharedModels
{
    public class BaseEntity
    {
        public string CreatedAt { get; set; } = String.Empty;
        public string UpdatedAt { get; set; } = String.Empty;
    }
}
