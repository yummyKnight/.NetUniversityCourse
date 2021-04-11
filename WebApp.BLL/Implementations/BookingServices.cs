using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.BLL.Contracts;
using WebApp.BLL.Implementations;
using WebApp.Domain;
using WebApp.Domain.Contracts;
using EntityBooking = WebApp.DAL.Entities.Booking;
using DomainBooking = WebApp.Domain.Booking;
using IBookingRep =
    WebApp.DAL.IRepository<WebApp.Domain.Booking, WebApp.Domain.Contracts.IBookingContainer,
        WebApp.Domain.Models.BookingUpdateModel>;
using WebApp.Domain.Models;

namespace WebApp.BLL.Implementations {
    public class
        BookingGetService : GenericGetService<IBookingRep, BookingUpdateModel, Domain.Booking, IBookingContainer> {
        public override async Task ValidateAsync(IBookingContainer model) {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var booking = await GetAsync(model);
            if (model.BookingId.HasValue && booking == null)
            {
                throw new InvalidOperationException($"Booking not found by id {model.BookingId}");
            }
        }

        public BookingGetService(IBookingRep repository) : base(repository) {
        }
    }
}

public class BookingUpdateService : IUpdateService<BookingUpdateModel, IBookingContainer, DomainBooking> {
    private IBookingRep _repository;
    private IGetService<IBookingContainer, DomainBooking> booking_service;
    private IGetService<IClientContainer, Client> client_service;
    private IGetService<IRoomContainer, Room> room_service;

    public BookingUpdateService(IBookingRep repository, IGetService<IBookingContainer, Booking> bookingService,
        IGetService<IClientContainer, Client> clientService, IGetService<IRoomContainer, Room> roomService) {
        _repository = repository;
        booking_service = bookingService;
        client_service = clientService;
        room_service = roomService;
    }

    public async Task<Booking> UpdateAsync(BookingUpdateModel model) {
        await booking_service.ValidateAsync(model);
        await client_service.ValidateAsync(model);
        await room_service.ValidateAsync(model);
        return await _repository.UpdateAsync(model);
    }
}

public class BookingCreateService : ICreateService<BookingUpdateModel, IBookingContainer, DomainBooking> {
    private IBookingRep _repository;
    private IGetService<IClientContainer, Client> client_service;
    private IGetService<IRoomContainer, Room> room_service;

    public BookingCreateService(IBookingRep repository, IGetService<IClientContainer, Client> clientService,
        IGetService<IRoomContainer, Room> roomService) {
        _repository = repository;
        client_service = clientService;
        room_service = roomService;
    }

    public async Task<Booking> CreateAsync(BookingUpdateModel model) {
        await client_service.ValidateAsync(model);
        await room_service.ValidateAsync(model);
        return await _repository.CreateAsync(model);
    }
}

public class BookingDeleteService : IDeleteService<IBookingContainer> {
    private IBookingRep _repository;
    private IGetService<IBookingContainer, DomainBooking> booking_service;

    public BookingDeleteService(IBookingRep repository, IGetService<IBookingContainer, Booking> bookingService) {
        _repository = repository;
        booking_service = bookingService;
    }

    public async Task DeleteAsync(IBookingContainer model) {
        await booking_service.ValidateAsync(model);
        await _repository.DeleteAsync(model);
    }
}