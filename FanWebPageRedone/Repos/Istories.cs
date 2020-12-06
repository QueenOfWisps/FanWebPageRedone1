using FanWebPageRedone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanWebPageRedone.Repos
{
    public interface Istories
    {
        IQueryable<Story> Story { get; }

        void AddStory(Story story);

        Story GetPostByTitle(string Title);

    }
}
