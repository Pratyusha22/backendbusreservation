using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BusReservation.Models
{
    public partial class Tbldriver
    {
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string DriverContact { get; set; }
        public int? BusId { get; set; }

        public virtual Tblbus Bus { get; set; }
    }
}
