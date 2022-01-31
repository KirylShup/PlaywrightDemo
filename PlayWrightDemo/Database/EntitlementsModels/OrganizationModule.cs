using System;
using System.ComponentModel.DataAnnotations;

namespace PlayWrightDemo.Database.Models
{
    public class OrganizationModule
    {
        [Key]
        public Guid OrganizationModuleID { get; set; }
        public Guid OrganizationID { get; set; }
        public int ModuleID { get; set; }
        public byte StatusTypeID { get; set; }
        public int? GracePeriodOverride { get; set; }
        public int EntitlementCreatedByTypeID { get; set; }
        public Organization Organization { get; set; }
    }
}
