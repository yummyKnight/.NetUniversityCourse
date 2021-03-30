using WebApp.Domain.Contracts;

namespace WebApp.Domain.Models {
    public class PaymentIdentityModel : IPaymentContainer {
        public int? PaymentId { get; }

        public PaymentIdentityModel(int id) {
            PaymentId = id;
        }
    }
}