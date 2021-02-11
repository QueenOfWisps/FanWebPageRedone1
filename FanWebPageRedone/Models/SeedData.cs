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
        //public static void init(StoriesContext context)
        //{
        //    //for loops could be the problem.. finish this as you can. 

        //    //context.Database.EnsureDeleted();
        //    context.Database.EnsureCreated();
        //    if (!context.Story.Any())
        //    {


        //context.Database.Migrate();
        /*
        if (context.User.Any())
        {
            return;
        }
        */
        //List<string> rolesname = new List<string>() { "User", "Admin" };
        //var roles = context.Roles.ToList();
        //foreach (var r in rolesname)
        //{
        //    if (roles.Where(role => role.Name == r).FirstOrDefault() == null)
        //    {
        //        context.Roles.Add(new IdentityRole(r));

        //    }
        //}


        // var users = new AppUser[]
        // {
        //new AppUser {Name="neva", UserName="neva"},
        //new AppUser {Name="thai", UserName = "thai"},
        //new AppUser {Name="telletubby", UserName = "telletubby"}


        // };

        //foreach (AppUser u in users)
        //{
        //    if (context.User.Where(u => u.UserName == u.UserName).FirstOrDefault() == null)
        //    {
        //        u.RoleNames = new List<string>();
        //        u.RoleNames.Add("Admin");
        //        context.User.Add(u);
        //    }

        ////}
        //context.SaveChanges();

        //    var stories = new Story[]
        //    {
        //    new Story{Topic="lana is cool",Date=DateTime.Parse("03/05/2019"),Text="Lana is an angel and i love her",User=new AppUser{Name="neva"} },
        //    new Story{Topic="lana is my hero",Date=DateTime.Parse("03/03/2012"),Text="Lana gave me cookies",User=new AppUser{Name="thai"} },
        //    new Story{Topic="lana is the bees knees",Date=DateTime.Parse("01/01/2000"),Text="Lana is so good at making tubby toast",User=new AppUser{Name="telletubby"} },
        //    };

        //    foreach (Story s in stories)
        //    {
        //        context.Story.Add(s);
        //    }
        //    context.SaveChanges();

        //}
        //THE ABOVE WAS THE OLD WAY TO SEED DATA, IF YOU ARE USING ROLES YOU MUST UJSE THE ROLE MANAGER TO MANAGE ROLES INSTEAD OF ADDING THEM DIRECTLY AND YOU MUST USE THE USER MANAGER TO ADD USERS THAT YOU WANT TO HAVE ROLES. 


        public static void init(StoriesContext context, UserManager<AppUser> userManager,
               RoleManager<IdentityRole> roleManager)
        {
            if (!context.Story.Any())  // this is to prevent duplicate data from being added
            {
                // TODO: check the results and do something if the operation failed--if it ever does
                var result = roleManager.CreateAsync(new IdentityRole("User")).Result;
                result = roleManager.CreateAsync(new IdentityRole("Admin")).Result;

                // Seeding a default administrator. They will need to change their password after logging in.
                AppUser siteadmin = new AppUser
                {
                    UserName = "SiteAdmin",
                    Name = "Site Admin"
                };
                userManager.CreateAsync(siteadmin, "Secret-123").Wait();
                IdentityRole adminRole = roleManager.FindByNameAsync("Admin").Result;
                userManager.AddToRoleAsync(siteadmin, adminRole.Name);

                // Seed users and reviews for manual site testing

                AppUser Telletubby = new AppUser
                {
                    UserName = "TInkyWinkyLovesYou",
                    Name = "TinkyWinky"
                };
                context.Users.Add(Telletubby);
                context.SaveChanges();   // This will add a UserID to the reviewer object

                Story telestory = new Story
                {
                    Topic = "Lana Del Rey is beautiful.",
                    Text = "She makes the best Tubby Toast!",
                    User = Telletubby,
                    Date = DateTime.Parse("11/1/2020")
                };
                context.Story.Add(telestory);  // queues up the review to be added to the DB

                AppUser Charmy = new AppUser
                {
                    UserName = "Charmyy",
                    Name = "Charmy"
                };
                context.Users.Add(Charmy);
                context.SaveChanges();   // This will add a UserID to the reviewer object

                Story story = new Story
                {
                    Topic = "I love lana Shes an icon.",
                    Text = "Lana del rey let me have an autograph",
                    User = Charmy,
                    Date = DateTime.Parse("11/15/2020")
                };
                context.Story.Add(story);
                context.SaveChanges();
                // My next two reviews will be by the same user, so I will create
                // the user object once and store it so that both reviews will be
                // associated with the same entity in the DB.

                AppUser reviewerBrianBird = new AppUser
                {
                    UserName = "BBird",
                    Name = "Brian Bird"
                };
                context.Users.Add(reviewerBrianBird);
                context.SaveChanges();   // This will add a UserID to the reviewer object
                                         //context.SaveChanges(); // stores all the reviews in the DB
            }


        }
    }
}
