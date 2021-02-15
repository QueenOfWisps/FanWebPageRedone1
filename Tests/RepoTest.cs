using FanWebPageRedone.Controllers;
using FanWebPageRedone.Models;
using FanWebPageRedone.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Tests
{
    public class RepoTest
    {
        [Fact]
        public void AddStoryTest()
        {

            // Arrange

            var fakerepo = new FakeStoryRepo();
            var controller = new HomeController(fakerepo,null);
            var story = new Story()
            {
                //create values for empty repo.
                Topic = "Love this site",
                 User = new AppUser() { Name = "Me" },
                Text = "Wow lana del rey is so cool"
            };

            //Act
            controller.Stories(story);
            var fetchStory = fakerepo.Story.ToList()[0];

            //Ensure that the review was added to the repository
            Assert.True(fetchStory.User.Name== story.User.Name);
        }

    }
}
