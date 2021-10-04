using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BusReservation.Models
{
    public partial class Tbladmin
    {
        public int AdminId { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}
