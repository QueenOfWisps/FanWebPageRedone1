using FanWebPageRedone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FanWebPageRedone.Models
{
    public class AppUser : IdentityUser
    {
        // this is a primary key, for the user table. it will also serve as a forign key in Story.cs
        //public int UserId { get; set; } when inheriting from identity user, you remove the id because identity user already has an id , having two id fields is conflictin. 
        //indentity user also has fields for email, username, and password phone, logins,and more.
       [StringLength(50, MinimumLength= 1)]
       [Required]
        public string Name { get; set; }
     
    }
}
