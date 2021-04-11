using System.ComponentModel.DataAnnotations;

namespace WebApp.DTO.Request {
    public class ClientUpdateDTO : ClientCreateDTO {
        [Required(ErrorMessage = "ClientId is required")]
        public int ClientId { get; set; }
    }

    public class BookingUpdateDTO : BookingCreateDTO {
        [Required(ErrorMessage = "BookingId is required")]
        public int BookingId { get; set; }
    }

    public class PaymentUpdateDTO : PaymentCreateDTO {
        [Required(ErrorMessage = "PaymentId is required")]
        public int PaymentId { get; set; }
    }

    public class RoomUpdateDTO : RoomCreateDTO {
        [Required(ErrorMessage = "RoomId is required")]
        public int RoomId { get; set; }
    }
}