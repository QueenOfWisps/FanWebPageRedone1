using FanWebPageRedone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanWebPageRedone.Repos
{
    public class FakeStoryRepo : Istories
    {
        List<Story> stories = new List<Story>();
        public IQueryable<Story> Story { get { return stories.AsQueryable<Story>(); } }

        public void AddStory(Story story)
        {
            story.StoryId = stories.Count;
            stories.Add(story);
        }
        public void DeleteStory(Story story)
        {
            throw new NotImplementedException();

        }
        public void DeleteRange(string id)
        {
            throw new NotImplementedException();

        }
        public Story GetPostByTitle(string Title)
        {
            throw new NotImplementedException();
        }
    }
}
