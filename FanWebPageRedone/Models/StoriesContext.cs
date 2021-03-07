using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FanWebPageRedone.Models
{
    //connection strings 
    //local: "Server=(localdb)\\mssqllocaldb;Database=fanwebpageredone;Trusted_Connection=True;MultipleActiveResultSets=true;" 
    //Online: "Data Source=SQL5102.site4now.net;Initial Catalog=DB_A704DF_fanwebpageredone;User Id=DB_A704DF_fanwebpageredone_admin;Password=YOUR_DB_PASSWORD


    public class StoriesContext : IdentityDbContext
    {
        public StoriesContext(
            DbContextOptions<StoriesContext>options) : base(options) { 
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        

        public DbSet<Story> Story { get; set;  }

        //public DbSet<AppUser>  User  { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
