using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FanWebPageRedone.Models
{
    public class StoriesContext : DbContext
    {
        public StoriesContext(
            DbContextOptions<StoriesContext>options) : base(options) { 
            
        }

        

        public DbSet<Story> Story { get; set;  }
        public DbSet<User>  User  { get; set; }

    }
}
