using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanWebPageRedone.Models
{
    public class SeedData
    {
        public static void init(StoriesContext context)
        {
            context.Database.EnsureCreated();
            /*
            if (context.User.Any())
            {
                return;
            }
            */

            var users = new AppUser[]
            {
               new AppUser {Name="neva"},
               new AppUser {Name="thai"},
               new AppUser {Name="telletubby"}

            };

            foreach(AppUser u in users)
            {
                context.User.Add(u);

            }
            context.SaveChanges();

            var stories = new Story[]
            {
                new Story{Topic="lana is cool",Date=DateTime.Parse("03/05/2019"),Text="Lana is an angel and i love her",User=new AppUser{Name="neva"} },
                new Story{Topic="lana is my hero",Date=DateTime.Parse("03/03/2012"),Text="Lana gave me cookies",User=new AppUser{Name="thai"} },
                new Story{Topic="lana is the bees knees",Date=DateTime.Parse("01/01/2000"),Text="Lana is so good at making tubby toast",User=new AppUser{Name="telletubby"} },
            };

            foreach(Story s in stories)
            {
                context.Story.Add(s);
            }
            context.SaveChanges();
            
        }

        
        
    }
}
