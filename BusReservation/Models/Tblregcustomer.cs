using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BusReservation.Models
{
    public partial class Tblregcustomer
    {
        public Tblregcustomer()
        {
            Tblbooking = new HashSet<Tblbooking>();
        }

        public string UserName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerGender { get; set; }
        public int? CustomerAge { get; set; }
        public string Password { get; set; }
        public double? WalletAmount { get; set; }

        public virtual ICollection<Tblbooking> Tblbooking { get; set; }
    }
}
