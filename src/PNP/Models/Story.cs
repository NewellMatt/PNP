using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PNP.Models
{
    [Table("Stories")]
    public class Story
    {
        [Key]
        public int StoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public Story(string content, int id = 0)
        {
            Content = content;
        }

        public Story() { }
    }
}
