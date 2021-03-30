using WebApp.Domain.Base;
using WebApp.Domain.Contracts;

namespace WebApp.Domain.Models {
    public class PaymentTypeUpdateModel : BasePaymentType, IPaymentTypeContainer {
        public int? PaymentTypeId { get; set; }
    }
}