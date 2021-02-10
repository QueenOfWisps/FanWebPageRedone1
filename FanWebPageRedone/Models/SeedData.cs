using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
          
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            if (!context.Story.Any())
            {


                //context.Database.Migrate();
                /*
                if (context.User.Any())
                {
                    return;
                }
                */
                List<string> rolesname = new List<string>() { "User", "Admin" };
                var roles = context.Roles.ToList();
                foreach (var r in rolesname)
                {
                    if (roles.Where(role => role.Name == r).FirstOrDefault() == null)
                    {
                        context.Roles.Add(new IdentityRole(r));

                    }
                }
                context.SaveChanges();

                var users = new AppUser[]
                {
               new AppUser {Name="neva", UserName="neva"},
               new AppUser {Name="thai", UserName = "thai"},
               new AppUser {Name="telletubby", UserName = "telletubby"}


                };

                foreach (AppUser u in users)
                {
                    if (context.User.Where(u => u.UserName == u.UserName).FirstOrDefault() == null)
                    {
                        u.RoleNames = new List<string>();
                        u.RoleNames.Add("Admin");
                        context.User.Add(u);
                    }

                }
                context.SaveChanges();

                var stories = new Story[]
                {
                new Story{Topic="lana is cool",Date=DateTime.Parse("03/05/2019"),Text="Lana is an angel and i love her",User=new AppUser{Name="neva"} },
                new Story{Topic="lana is my hero",Date=DateTime.Parse("03/03/2012"),Text="Lana gave me cookies",User=new AppUser{Name="thai"} },
                new Story{Topic="lana is the bees knees",Date=DateTime.Parse("01/01/2000"),Text="Lana is so good at making tubby toast",User=new AppUser{Name="telletubby"} },
                };

                foreach (Story s in stories)
                {
                    context.Story.Add(s);
                }
                context.SaveChanges();

            }
        }
        
        
    }
}
