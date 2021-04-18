using System;
using WebApp.Domain;

namespace WebApp.BLL.Contracts {
    public interface IPayment : ICancelable {
        Payment Create(Client client, Booking booking, uint amount);
        
        Payment GetById(Guid id);
    }
}