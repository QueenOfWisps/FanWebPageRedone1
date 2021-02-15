using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanWebPageRedone.Models
{
    public class CommentVM
    {
        public int StoryID { get; set; }    // This identifies the reivew being commented on
        public int BookTitle { get; set; }
        public String CommentText { get; set; }
    }
}
