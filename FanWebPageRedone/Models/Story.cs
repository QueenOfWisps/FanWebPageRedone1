using FanWebPageRedone.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FanWebPageRedone.Models
{
    public class Story
    {
        private List<Comment> comments = new List<Comment>();
        //setting up a pimary key for story.
        public int StoryId { get; set; }
            
           [MaxLength(50)]
            public string StoryTitle { get; set; }
            public string Topic { get; set; }
            //setting up foriegn key from user in story. entity framework automatically sets up a relationship between these two tables 
            //when a username of type user is created. it just knows its from user. its magic.
            public virtual AppUser User { get; set; }
            [StringLength(500,MinimumLength=20)]
            public string Text { get; set; }
            public DateTime Date { get; set; }

           public List<Comment> Comments
           {
               get { return comments; }
           }



        public List<Story> Seed()
        {
            //be sure to call in startup <3.


            //seeded data inside where its own table lives.
            //instantiate a new list of type usermodel
            var rec = new List<Story>();
            //add records to the list. 
            rec.Add(new Story() { Text="mypost" });
            rec.Add(new Story() { Text="post3" });
            rec.Add(new Story() { Text="hello" });
            rec.Add(new Story() { Text = "Tony" });

            return rec;//return list.
        }
    }
}

