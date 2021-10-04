using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BusReservation.Models
{
    public partial class TblPassengerDetails
    {
        public int PassengerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public int? NumberOfPassengers { get; set; }
        public int? BusId { get; set; }

        public virtual Tblbus Bus { get; set; }
    }
}
