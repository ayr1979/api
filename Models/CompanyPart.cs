using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.API.Models
{
    public class CompanyPart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrderPartId { get; set; }
        public DateTime Added { get; set; }
        public CompanyPart()
        {
            Added = System.DateTime.Now;
        
        }

    }
}
