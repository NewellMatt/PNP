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
        public string Description { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
