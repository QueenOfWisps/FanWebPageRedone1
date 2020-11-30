using FanWebPageRedone.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanWebPageRedone.Models
{
    public class User
    {
        // this is a primary key, for the user table. it will also serve as a forign key in Story.cs
        public int UserId { get; set; }
        public string Name { get; set; }
     
    }
}
