using System;
using WebApp.BLL.Contracts;
using WebApp.Domain;
using WebApp.DAL;

namespace WebApp.BLL.Implementations {
    public class BookingBll : IBooking {
        
        private readonly IRepository<Booking> repository;
        public void Cancel() {
            
        }

        public void Delete() {
            throw new NotImplementedException();
        }

        public Booking Create(Client client, Room room, DateTime checkIn, DateTime checkOut, DateTime reservedDay) {
            throw new NotImplementedException();
        }

        public Booking GetById(Guid id) {
            throw new NotImplementedException();
        }

        public bool CheckConflicts() {
            throw new NotImplementedException();
        }

        public void MakeProlongation(DateTime newCheckout) {
            throw new NotImplementedException();
        }

        public void CalculateDiscount() {
            throw new NotImplementedException();
        }
    }
}