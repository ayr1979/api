using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DatingApp.API.Models
{
    public class User : IdentityUser<int>
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
        public string buildingstreet {get;set;}
        public string buildingpostal { get; set; }
        public string buildingcity { get; set; }
        public string owneremail { get; set; }
        public string owneraddress { get; set; }
        public string propertymgmtemail { get; set; }
        public string propertymgmtaddress { get; set; }
        public string credittermsemail { get; set; }
        public string credittersaddress { get; set; }
        public string billingaddress { get; set; }
        public string alarmsysteminfo { get; set; }
        public string cardaccessinfo { get; set; }
        public string videosurveillanceinfo { get; set; }
        public string alarmsystempasswords { get; set; }
        public string videosurveillancepasswords { get; set; }
        public string cardaccesspasswords { get; set; }
        public string doorentryinfo { get; set; }
        public string firealarminfo { get; set; }
        public string monitoringinfo { get; set; }
        public string nursecallinfo { get; set; }
        public string schoolpaginginfo { get; set; }
        public string audioinfo { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public User()
        {
            Created = System.DateTime.Now;
        }
    }
}