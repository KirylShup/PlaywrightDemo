using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlayWrightDemo.Database.Models
{
    public class Organization
    {
        [Key]
        public Guid OrganizationID { get; set; }
        public string Name { get; set; }
        public byte StatusTypeID { get; set; }
        public virtual List<User> User { get; set; }
        public virtual List<OrganizationModule> OrganizationModule { get; set; }
    }
}
