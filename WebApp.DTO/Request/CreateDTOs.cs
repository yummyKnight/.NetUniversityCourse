using System;
using System.ComponentModel.DataAnnotations;
using WebApp.Domain;
using WebApp.Domain.Base;

namespace WebApp.DTO.Request {
    public class ClientCreateDTO : BaseClient {
        [Required(ErrorMessage = "Full name is required")]
        public new string FullName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public new string Address { get; set; }

        public new uint OrdersNum { get; set; }
    }

    public class BookingCreateDTO {
        [Required(ErrorMessage = "ClientId is required")]
        public int? ClientId { get; set; }

        [Required(ErrorMessage = "RoomId is required")]
        public int? RoomId { get; set; }

        [Required(ErrorMessage = "ReservedDay is required")]
        public DateTime ReservedDay { get; set; }

        [Required(ErrorMessage = "CheckIn is required")]
        public DateTime CheckIn { get; set; }

        [Required(ErrorMessage = "CheckOut is required")]
        public DateTime CheckOut { get; set; }
    }

    // TODO: add PaymentTypeId
    public class PaymentCreateDTO {
        [Required(ErrorMessage = "BookingId is required")]
        public int? BookingId { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public uint? Amount { get; set; }

        public bool? IsCanceled { get; set; }
        public DateTime CanceledAt { get; set; }
    }

    public class RoomCreateDTO {
        [Required(ErrorMessage = "Price is required")]
        public uint? Price { get; set; }
    }

    public class RoomTypeCreateDTO {
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }
    }
}