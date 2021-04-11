using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.BLL.Contracts;
using WebApp.DAL;
using WebApp.Domain;
using WebApp.Domain.Contracts;
using EntityBooking = WebApp.DAL.Entities.Booking;
using DomainBooking = WebApp.Domain.Booking;
using IBookingRep =
    WebApp.DAL.IRepository<WebApp.Domain.Booking, WebApp.Domain.Contracts.IBookingContainer,
        WebApp.Domain.Models.BookingUpdateModel>;
using WebApp.Domain.Models;

namespace WebApp.BLL.Implementations {
    // public class BookingGetService : IGetService<IBookingContainer, DomainBooking>{
    //     public Task<IEnumerable<DomainBooking>> GetAsync() {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     public Task<DomainBooking> GetAsync(IBookingContainer employee) {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     public Task ValidateAsync(IBookingContainer model) {
    //         throw new System.NotImplementedException();
    //     }
    // }
    //
    // public class BookingUpdateService : IUpdateService<BookingUpdateModel, DomainBooking> {
    //     private IBookingRep _repository;
    //     private IClientGetService _service;
    //
    //     public Task<Booking> UpdateAsync(BookingUpdateModel model) {
    //         throw new System.NotImplementedException();
    //     }
    // }
    //
    // public class BookingCreateService : ICreateService<BookingUpdateModel, DomainBooking> {
    //     private IClientRepository _repository;
    //
    //     public Task<Booking> CreateAsync(BookingUpdateModel model) {
    //         throw new System.NotImplementedException();
    //     }
    // }
    //
    // public class BookingDeleteService : IDeleteService<IBookingContainer> {
    //     private IClientRepository _repository { get; }
    //     private IClientGetService _service { get; }
    //
    //     public Task DeleteAsync(IBookingContainer model) {
    //         throw new System.NotImplementedException();
    //     }
    // }
}