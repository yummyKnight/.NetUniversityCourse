using WebApp.Domain.Base;

namespace WebApp.DTO.Read {
    public class ClientDTO : BaseClient {
        public int Id { get; set; }
    }

    public class BookingDTO : BaseBooking {
        public int Id { get; set; }
    }

    public class PaymentDTO : BasePayment {
        public int Id { get; set; }
    }

    public class RoomDTO : BaseRoom {
        public int Id { get; set; }
    }
}