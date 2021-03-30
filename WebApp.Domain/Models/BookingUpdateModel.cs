using WebApp.Domain.Base;
using WebApp.Domain.Contracts;

namespace WebApp.Domain.Models {
    public class BookingUpdateModel : BaseBooking, IClientContainer, IRoomContainer, IBookingContainer {
        public int? ClientId { get; set; }
        public int? RoomId { get; set; }
        public int? BookingId { get; set;}
    }
}