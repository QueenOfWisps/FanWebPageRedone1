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
       private StoriesContext context;



        public StoryRepo(StoriesContext s)
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
            story.User = context.User.Where(u => u.Name == story.User.Name).FirstOrDefault();// allowing the story object to be virtual 
            //maked this possible. assigning full connected object store.user.name which is an asp net user object. first or default is a search. 
            //it will return first object or if it is empty it will return null.
            context.Story.Add(story);
            context.SaveChanges();
        }

        public void DeleteStory(Story story)
        {
            story.User = context.User.Where(u => u.Name == story.User.Name).FirstOrDefault();
            context.Story.Remove(story);
            context.SaveChanges();
        }
    
        public void DeleteRange(string id)
        {
            var stories = context.Story.Where(s => s.User.Id == id).ToList();
            context.Story.RemoveRange(stories);
            context.SaveChanges();
        }
        public Story GetPostByTitle(string Title)
        {
            throw new NotImplementedException();
        }
    }
}
