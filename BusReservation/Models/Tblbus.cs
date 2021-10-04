using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BusReservation.Models
{
    public partial class Tblbus
    {
        public Tblbus()
        {
            TblPassengerDetails = new HashSet<TblPassengerDetails>();
            Tblbusschedule = new HashSet<Tblbusschedule>();
            Tbldriver = new HashSet<Tbldriver>();
        }

        public int BusId { get; set; }
        public string BusNumber { get; set; }
        public string BusType { get; set; }
        public int? Capacity { get; set; }

        public virtual ICollection<TblPassengerDetails> TblPassengerDetails { get; set; }
        public virtual ICollection<Tblbusschedule> Tblbusschedule { get; set; }
        public virtual ICollection<Tbldriver> Tbldriver { get; set; }
    }
}
