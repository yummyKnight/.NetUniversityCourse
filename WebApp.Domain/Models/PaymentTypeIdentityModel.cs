using WebApp.Domain.Contracts;

namespace WebApp.Domain.Models {
    public class PaymentTypeIdentityModel : IPaymentTypeContainer {
        public int? PaymentTypeId { get; }

        public PaymentTypeIdentityModel(int id) {
            PaymentTypeId = id;
        }
    }
}