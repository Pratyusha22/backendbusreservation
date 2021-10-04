using BusReservation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegCustomerController : ControllerBase
    {
        BusReservationContext context;
        public RegCustomerController(BusReservationContext _context) {
            context = _context;
        }



        [HttpGet]
        public IActionResult Get()
        {
            return Ok(context.Tblregcustomer);
        }




        //[HttpGet("{Username}")]
        //public IActionResult Get(string Username)
        //{
        //    var user = context.Tblregcustomer.Where(x => x.UserName == Username).FirstOrDefault();
        //    if (user == null)
        //        return Ok("User not found");
        //    else
        //    { return Ok(user); }
        //}

        [HttpPost]
        public IActionResult Register(Tblregcustomer customer)
        {

            var cust = context.Tblregcustomer.Where(x => x.UserName == customer.UserName).FirstOrDefault();
            if (cust == null)
            {
                context.Tblregcustomer.Add(customer);
                context.SaveChanges();
                return Ok(customer);
            }
            else
            {
                return BadRequest("Username already exists");
            }

        }
        [HttpPost("Login")]
        public IActionResult Login(Tblregcustomer customer)
        {
            var cust = context.Tblregcustomer.Where(t => t.UserName == customer.UserName && t.Password == customer.Password).FirstOrDefault();
            if (cust != null)
            {

                return Ok();

            }
            else {
                return Unauthorized();
            }


        }
    }
}
