using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlayWrightDemo.Database.Models
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }
        public string EmailAddress { get; set; }
        public byte StatusTypeID { get; set; }
        public Guid OrganizationID { get; set; }
        public byte UserTypeID { get; set; }
        public virtual List<InviteToJoin> InvitationToJoin { get; set; }
        public Organization Organization { get; set; }
    }
}
