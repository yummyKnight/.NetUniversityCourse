using System;
using WebApp.Domain.Contracts;

namespace WebApp.Domain.Models {
    public class BookingIdentityModel : IBookingContainer {
        public int? BookingId { get; }

        public BookingIdentityModel(int id) {
            BookingId = id;
        }
    }
}