using System;
using System.ComponentModel.DataAnnotations;

namespace PlayWrightDemo.Database.Models
{
    public class InviteToJoin
    {
        [Key]
        public Guid InviteToJoinID { get; set; }
        public Guid OrganizationID { get; set; }
        public Guid InviterUserID { get; set; }
        public string InviteeEmailAddress { get; set; }
        public int ResendEmailCount { get; set; }
        public byte StatusTypeID { get; set; }
        public int RoleID { get; set; }
        public User User { get; set; }
    }
}
