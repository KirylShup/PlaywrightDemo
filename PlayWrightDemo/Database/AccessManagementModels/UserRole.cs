using System;

namespace PlayWrightDemo.Database.AccessManagementModels
{
    public class UserRole
    {
        public Guid UserRoleID { get; set; }
        public Guid UserID { get; set; }
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }
    }
}
