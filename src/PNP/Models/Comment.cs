using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PNP.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Description { get; set; }
        public int StoryId { get; set; }
        public virtual Story Story { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
