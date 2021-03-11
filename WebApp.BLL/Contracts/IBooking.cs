using System;
using WebApp.Domain;

namespace WebApp.BLL.Contracts {
    public interface IBooking : ICancelable {
        Booking Create(Client client, Room room, DateTime checkIn, DateTime checkOut, DateTime reservedDay);
        Booking GetById(Guid id);

        bool CheckConflicts();

        void MakeProlongation(DateTime newCheckout);

        void CalculateDiscount();
    }
}