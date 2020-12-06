using FanWebPageRedone.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanWebPageRedone.Repos
{
    public class StoryRepo : Istories
    {
        StoriesContext context;



        private StoryRepo(StoriesContext s)
        {
            context = s;
        }
        public IQueryable<Story> Story
        {
            get
            {
                return context.Story.Include(story => story.User);  
            }
        } 

        public void AddStory(Story story)
        {
            context.Story.Add(story);
            context.SaveChanges();
        }

        public Story GetPostByTitle(string Title)
        {
            throw new NotImplementedException();
        }
    }
}
