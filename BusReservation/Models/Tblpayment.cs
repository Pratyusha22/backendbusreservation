using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BusReservation.Models
{
    public partial class Tblpayment
    {
        public int PaymentId { get; set; }
        public int? BookingId { get; set; }
        public double? AmountPaid { get; set; }
        public string PaymentDate { get; set; }

        public virtual Tblbooking Booking { get; set; }
    }
}
