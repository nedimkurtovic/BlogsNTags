using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogsNTags.SharedModels
{
    public class Tag:BaseEntity
    {
        public string Name { get; set; } = String.Empty;

    }
}
