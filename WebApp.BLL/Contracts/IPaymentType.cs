using System;
using WebApp.Domain;

namespace WebApp.BLL.Contracts {
    public interface IPaymentType {
        PaymentType Create(string payType);
        PaymentType GetById(Guid id);
    }
}