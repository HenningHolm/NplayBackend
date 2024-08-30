using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPlay.Shared.Models.Settings
{
    public class OrganisationSettings
    {
        public string Domain { get; set; }
        public string OrgFullName { get; set; }
        public string RecurringDescriptionMessage { get; set; }
        public string RecurringProductName { get; set; }
        public string ECommerceDescriptionMessage { get; set; }
        public string ECommerceProductName { get; set; }
        public string Currency { get; set; }
        public string Interval { get; set; }
        public string Scope { get; set; }
        public int IntervalCount { get; set; }

    }

}
