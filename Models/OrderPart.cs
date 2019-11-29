using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Models
{
    public class OrderPart
    {//properties for property management order entry system


        public int Id { get; set; }

        [Required]
        public string PartName { get; set; }

        [Required]
        public string PartDescription { get; set; }
        public string PartUrl { get; set; }
        public string SKU { get; set; }
        public bool inStock { get; set; }
        public bool isActive { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public string Url { get; set; }
        public int? UserId { get; set; }
        public DateTime added { get; set; }
        public OrderPart()
        {
            added = System.DateTime.Now;
        }
    }
}