using FanWebPageRedone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanWebPageRedone.Models
{
    public class Story
    {
        //setting up a pimary key for story.
        public int StoryId { get; set; }
        public string StoryTitle { get; set; }
        public string Topic { get; set; }
        //setting up foriegn key from user in story. entity framework automatically sets up a relationship between these two tables 
        //when a username of type user is created. it just knows its from user. its magic.
        public User UserName { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}

