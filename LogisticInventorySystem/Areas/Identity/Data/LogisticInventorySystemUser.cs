using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LogisticInventorySystem.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the LogisticInventorySystemUser class
    public class LogisticInventorySystemUser : IdentityUser
    {
        [PersonalData]
        public string StaffID { get; set; }
        [PersonalData]
        public string StaffName { get; set; }


    }
}
