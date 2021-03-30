using System.Security.Principal;
using WebApp.Domain.Base;
using WebApp.Domain.Contracts;

namespace WebApp.Domain.Models {
    public class PaymentUpdateModel : BasePayment, IClientContainer, IBookingContainer, IPaymentContainer, IPaymentTypeContainer {
        public int? ClientId { get; set; }
        public int? BookingId { get; set;}
        public int? PaymentId { get; set;}
        public int? PaymentTypeId { get; set;}
    }
}