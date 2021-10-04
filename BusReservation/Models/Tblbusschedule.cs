using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BusReservation.Models
{
    public partial class Tblbusschedule
    {
        public Tblbusschedule()
        {
            Tblbooking = new HashSet<Tblbooking>();
        }

        public int ScheduleId { get; set; }
        public string Startingpt { get; set; }
        public string Destination { get; set; }
        public string ScheduledDate { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public double? FareAmount { get; set; }
        public int? BusId { get; set; }

        public virtual Tblbus Bus { get; set; }
        public virtual ICollection<Tblbooking> Tblbooking { get; set; }
    }
}
