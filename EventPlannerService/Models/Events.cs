using System;
using System.Collections.Generic;

namespace EventPlannerService.Models
{
    public partial class Events
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Venue { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime EventDate { get; set; }
    }
}
