using AutoMapper;
using WebApp.Domain;
using WebApp.Domain.Contracts;
using WebApp.Domain.Models;
using WebApp.DTO.Read;
using WebApp.DTO.Request;

namespace WebAPI {
    public class AutoMapperProfile : Profile {
        public AutoMapperProfile() {
            // Client
            CreateMap<WebApp.DAL.Entities.Client, WebApp.Domain.Client>();
            CreateMap<IClientContainer, WebApp.DAL.Entities.Client>().ForMember("Id",
                opt => opt.MapFrom(c => c.ClientId));
            this.CreateMap<Client, ClientDTO>();
            this.CreateMap<ClientUpdateModel, Client>();
            this.CreateMap<ClientCreateDTO, ClientUpdateModel>();
            this.CreateMap<ClientUpdateDTO, ClientUpdateModel>();
            this.CreateMap<ClientUpdateModel, WebApp.DAL.Entities.Client>();
            this.CreateMap<WebApp.Domain.Client, ClientDTO>();
            // Payment
            CreateMap<WebApp.DAL.Entities.Payment, WebApp.Domain.Payment>();
            CreateMap<IPaymentContainer, WebApp.DAL.Entities.Payment>().ForMember("Id",
                opt => opt.MapFrom(c => c.PaymentId));
            this.CreateMap<Payment, PaymentDTO>();
            this.CreateMap<PaymentUpdateModel, Payment>();
            this.CreateMap<PaymentCreateDTO, PaymentUpdateModel>();
            this.CreateMap<PaymentUpdateDTO, PaymentUpdateModel>();
            this.CreateMap<PaymentUpdateModel, WebApp.DAL.Entities.Payment>();
            this.CreateMap<WebApp.Domain.Payment, PaymentDTO>();
            // Room
            CreateMap<WebApp.DAL.Entities.Room, WebApp.Domain.Room>();
            CreateMap<IRoomContainer, WebApp.DAL.Entities.Room>().ForMember("Id",
                opt => opt.MapFrom(c => c.RoomId));
            this.CreateMap<Room, RoomDTO>();
            this.CreateMap<RoomUpdateModel, Room>().ForMember("Id",
                opt => opt.MapFrom(c => c.RoomId));
            this.CreateMap<RoomCreateDTO, RoomUpdateModel>();
            this.CreateMap<RoomUpdateDTO, RoomUpdateModel>();
            // Booking
            CreateMap<WebApp.DAL.Entities.Booking, WebApp.Domain.Booking>();
            CreateMap<IBookingContainer, WebApp.DAL.Entities.Booking>().ForMember("Id",
                opt => opt.MapFrom(c => c.BookingId));
            this.CreateMap<Booking, BookingDTO>();
            this.CreateMap<BookingUpdateModel, Booking>();
            this.CreateMap<BookingCreateDTO, BookingUpdateModel>();
            this.CreateMap<BookingUpdateDTO, BookingUpdateModel>();
            this.CreateMap<BookingUpdateModel, WebApp.DAL.Entities.Booking>();
            this.CreateMap<WebApp.Domain.Booking, BookingDTO>();
        }
    }
}