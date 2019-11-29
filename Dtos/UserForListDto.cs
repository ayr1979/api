using DatingApp.API.Models;
using System;
using System.Collections.Generic;

namespace DatingApp.API.Dtos
{
    public class UserForListDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
    }
}