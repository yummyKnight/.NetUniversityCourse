using WebApp.Domain.Base;

namespace WebApp.Domain {
    public class PaymentType : BasePaymentType {
        public PaymentType(uint id) {
            Id = id;
        }

        public uint Id { get; }
    }
}