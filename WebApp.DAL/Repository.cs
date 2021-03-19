using System.Collections.Generic;
using WebApp.Domain;

namespace WebApp.DAL {
    public class Repository :  IRepository<Payment>, IRepository<Booking>, 
        IRepository<Room>, IRepository<Client>, IRepository<PaymentType>, IRepository<RoomType> {
        IEnumerable<Payment> IRepository<Payment>.GetObjectsList() {
            throw new System.NotImplementedException();
        }

        Payment IRepository<Payment>.GetById(int id) {
            throw new System.NotImplementedException();
        }

        public void Create(Payment item) {
            throw new System.NotImplementedException();
        }

        public void Update(Payment item) {
            throw new System.NotImplementedException();
        }

        void IRepository<Payment>.Delete(int id) {
            throw new System.NotImplementedException();
        }

        void IRepository<Payment>.Save() {
            throw new System.NotImplementedException();
        }

        IEnumerable<Booking> IRepository<Booking>.GetObjectsList() {
            throw new System.NotImplementedException();
        }

        Booking IRepository<Booking>.GetById(int id) {
            throw new System.NotImplementedException();
        }

        public void Create(Booking item) {
            throw new System.NotImplementedException();
        }

        public void Update(Booking item) {
            throw new System.NotImplementedException();
        }

        void IRepository<Booking>.Delete(int id) {
            throw new System.NotImplementedException();
        }

        void IRepository<Booking>.Save() {
            throw new System.NotImplementedException();
        }

        IEnumerable<Room> IRepository<Room>.GetObjectsList() {
            throw new System.NotImplementedException();
        }

        Room IRepository<Room>.GetById(int id) {
            throw new System.NotImplementedException();
        }

        public void Create(Room item) {
            throw new System.NotImplementedException();
        }

        public void Update(Room item) {
            throw new System.NotImplementedException();
        }

        void IRepository<Room>.Delete(int id) {
            throw new System.NotImplementedException();
        }

        void IRepository<Room>.Save() {
            throw new System.NotImplementedException();
        }

        IEnumerable<Client> IRepository<Client>.GetObjectsList() {
            throw new System.NotImplementedException();
        }

        Client IRepository<Client>.GetById(int id) {
            throw new System.NotImplementedException();
        }

        public void Create(Client item) {
            throw new System.NotImplementedException();
        }

        public void Update(Client item) {
            throw new System.NotImplementedException();
        }

        void IRepository<Client>.Delete(int id) {
            throw new System.NotImplementedException();
        }

        void IRepository<Client>.Save() {
            throw new System.NotImplementedException();
        }

        IEnumerable<PaymentType> IRepository<PaymentType>.GetObjectsList() {
            throw new System.NotImplementedException();
        }

        PaymentType IRepository<PaymentType>.GetById(int id) {
            throw new System.NotImplementedException();
        }

        public void Create(PaymentType item) {
            throw new System.NotImplementedException();
        }

        public void Update(PaymentType item) {
            throw new System.NotImplementedException();
        }

        void IRepository<PaymentType>.Delete(int id) {
            throw new System.NotImplementedException();
        }

        void IRepository<PaymentType>.Save() {
            throw new System.NotImplementedException();
        }

        IEnumerable<RoomType> IRepository<RoomType>.GetObjectsList() {
            throw new System.NotImplementedException();
        }

        RoomType IRepository<RoomType>.GetById(int id) {
            throw new System.NotImplementedException();
        }

        public void Create(RoomType item) {
            throw new System.NotImplementedException();
        }

        public void Update(RoomType item) {
            throw new System.NotImplementedException();
        }

        void IRepository<RoomType>.Delete(int id) {
            throw new System.NotImplementedException();
        }

        void IRepository<RoomType>.Save() {
            throw new System.NotImplementedException();
        }
    }
}