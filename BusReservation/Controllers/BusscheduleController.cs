using BusReservation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusscheduleController : ControllerBase
    {

        BusReservationContext context;
        public BusscheduleController(BusReservationContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public IActionResult Get() {

            return Ok(context.Tblbusschedule);
        }
        [HttpPost("GetBus")]
        public IActionResult GetBus(Tblbusschedule bus) {
            var buses = context.Tblbusschedule.Where(x => x.Startingpt == bus.Startingpt && x.Destination == bus.Destination);

            return Ok(buses);
        }

        [HttpGet("GetPdetails")]
        public IActionResult GetPdetails()
        {

            return Ok(context.TblPassengerDetails);
        }
        [HttpPost("PassengerDetails")]
        public IActionResult PassengerDetails(TblPassengerDetails passenger)
        {
            var pass = context.TblPassengerDetails.Where(x => x.PassengerId == passenger.PassengerId).FirstOrDefault();
            if (pass == null)
            {

                context.TblPassengerDetails.Add(passenger);
                context.SaveChanges();
                return Ok(passenger);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("Bookings")]
        public IActionResult GetBookingDetails(string name)
        {
            var bookingdetails = (from r in context.Tblbooking
                                  where r.UserName == name
                                  join s in context.Tblbusschedule on r.ScheduleId equals s.ScheduleId
                                  join b in context.Tblregcustomer on r.UserName equals b.UserName
                                  select new
                                  {
                                      b.CustomerName,
                                      s.Startingpt,
                                      s.Destination,
                                      s.ScheduledDate,
                                      s.DepartureTime,
                                      s.ArrivalTime,
                                      r.NumberOfSeats,
                                      r.TotalAmount,
                                      r.BookingId,
                                      r.BookingStatus
                                  }).ToList();
            return Ok(bookingdetails);
        }

        [HttpPost("Cancel")]
        public IActionResult CancelBooking(int bookingid)
        {

            var booking = context.Tblbooking.Where(c => c.BookingId == bookingid).FirstOrDefault();
            booking.BookingStatus = 0;
            context.SaveChanges();
            return Ok();

        }
        [HttpGet("Ticket")]
        public IActionResult GetTicket(int bookingid)
        {
            var d = (from r in context.Tblbooking
                     where r.BookingId == bookingid
                     join s in context.Tblbusschedule on r.ScheduleId equals s.ScheduleId
                     join b in context.Tblregcustomer on r.UserName equals b.UserName
                     join u in context.Tblbus on s.BusId equals u.BusId
                     select new
                     {
                         b.CustomerName,
                         b.CustomerContact,
                         s.Startingpt,
                         s.Destination,
                         s.ScheduledDate,
                         s.DepartureTime,
                         s.ArrivalTime,
                         r.BookingId,
                         r.NumberOfSeats,
              
                         r.TotalAmount,
                         r.BookingStatus,
                         u.BusNumber
                     }).ToList();
            return Ok(d);
        }

        //[HttpPost("EntryBooking")]
        //public IActionResult EntryBookingDetails(string name)
        //{
        //    var entrybookingdetails = (from r in context.Tblbooking
        //                          where r.UserName == name
        //                          join s in context.Tblbusschedule on r.ScheduleId equals s.ScheduleId
        //                          join b in context.Tblregcustomer on r.UserName equals b.UserName
        //                          join u in context.Tblbus on s.BusId equals u.BusId
        //                               select new
        //                          {
        //                              b.CustomerName,
        //                              s.Startingpt,
        //                              s.Destination,
        //                              s.ScheduledDate,
        //                              s.DepartureTime,
        //                              s.ArrivalTime,
        //                              r.NumberOfSeats,
        //                              r.TotalAmount,
        //                              r.BookingId,
        //                              r.BookingStatus
        //                          }).ToList();
        //    return Ok(entrybookingdetails);
        //}

        [HttpGet("Getdetails")]
        public IActionResult Getdetails()
        {

            return Ok(context.Tblbooking);
        }

        [HttpPost("EnterDetails")]
        public IActionResult EnterDetails(Tblbooking details)
        {

                context.Tblbooking.Add(details);
                context.SaveChanges();
                return Ok(details);
           
        }
    }

}
