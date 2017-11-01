using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using U241017A.Data;

namespace _261017A.API.Controllers
{
    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            base.OnActionExecuted(actionExecutedContext);
        }
    }

    [AllowCrossSiteJson]
    public class BookingController : ApiController
    {
        Repository _repo = Repository.GetRepo;

        [HttpGet]
        public List<Booking> GetBookings()
        {
            return _repo.Bookings;
        }

        [HttpGet]
        public Booking GetBookingById(int id)
        {
            return _repo.Bookings.Find(q => q.Id == id);
        }

        [HttpDelete]
        public void RemoveBooking(int id)
        {
            Booking b = _repo.Bookings.Find(x => x.Id == id);
            _repo.Bookings.Remove(b);
        }
        [HttpPost]
        public void AddBooking(Booking b)
        {
            _repo.Add(b);
        }
    }
}
