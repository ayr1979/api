using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public class User: IdentityUser<int>
    {
   
        public string CompanyName { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public ICollection<CompanyPart> OrderParts { get; set; }
        public DateTime Created { get; set; }
        public string Telephone { get; set; }
        public ICollection<Photo> Photos { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public User()
        {
            Created = System.DateTime.Now;
        }
    }
}