using System;
using WebApp.Domain.Base;

namespace WebApp.Domain {
    public class Booking : BaseBooking {
        public Booking(int id) {
            Id = id;
        }

        public int? Id { get; set; }
    }
}