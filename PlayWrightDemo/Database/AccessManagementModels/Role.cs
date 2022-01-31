using System;
using System.Collections.Generic;

namespace PlayWrightDemo.Database.AccessManagementModels
{
    public class Role
    {
        public int RoleID { get; set; }
        public Guid OrganizationID { get; set; }
        public Guid? UserId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public byte IsDeleted { get; set; }
        public virtual List<UserRole> UserRole { get; set; }
    }
}
