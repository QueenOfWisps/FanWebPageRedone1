using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FanWebPageRedone.Models
{
    public class StoriesContext : IdentityDbContext
    {
        public StoriesContext(
            DbContextOptions<StoriesContext>options) : base(options) { 
            
        }

        

        public DbSet<Story> Story { get; set;  }
        public DbSet<AppUser>  User  { get; set; }

    }
}
