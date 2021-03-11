using System;
using WebApp.BLL.Contracts;
using WebApp.Domain;

namespace WebApp.BLL.Implementations {
    public class PaymentBll : IPayment {
        public void Cancel() {
            throw new NotImplementedException();
        }

        public void Delete() {
            throw new NotImplementedException();
        }

        public Payment Create(Client client, Booking booking, PaymentType type, uint amount) {
            throw new NotImplementedException();
        }

        public Payment GetById(Guid id) {
            throw new NotImplementedException();
        }
    }
}