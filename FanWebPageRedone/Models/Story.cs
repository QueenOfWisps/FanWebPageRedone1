using FanWebPageRedone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanWebPageRedone.Models
{
    public class Story
    {
        public string StoryTitle { get; set; }
        public string Topic { get; set; }
        public User UserName { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}

