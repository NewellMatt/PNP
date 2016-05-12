using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PNP.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Description { get; set; }
        public int StoryId { get; set; }
        public virtual Story Story { get; set; }
    }
}
