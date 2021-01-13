using FanWebPageRedone.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FanWebPageRedone.Models
{
    public class User
    {
        // this is a primary key, for the user table. it will also serve as a forign key in Story.cs
        public int UserId { get; set; }
        [StringLength(50, MinimumLength= 1)]
        [Required]
        public string Name { get; set; }
     
    }
}
