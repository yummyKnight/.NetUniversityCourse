using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.BLL.Contracts;
using WebApp.Domain.Contracts;
using WebApp.Domain.Models;
using WebApp.DTO.Read;
using WebApp.DTO.Request;
using EntityBooking = WebApp.DAL.Entities.Booking;
using DomainBooking = WebApp.Domain.Booking;
using IBookingRep =
    WebApp.DAL.IRepository<WebApp.Domain.Booking, WebApp.Domain.Contracts.IBookingContainer,
        WebApp.Domain.Models.BookingUpdateModel>;

namespace WebApp.WebAPI.Controllers {
    [ApiController]
    [Route("api/booking")]
    public class BookingController : ControllerBase {
        private ILogger<BookingController> Logger { get; }
        private IGetService<IBookingContainer, DomainBooking> BookingGetService { get; }

        private IUpdateService<BookingUpdateModel, IBookingContainer, DomainBooking>
            BookingUpdateService { get; }

        private ICreateService<BookingUpdateModel, IBookingContainer, DomainBooking>
            BookingCreateService { get; }

        private IDeleteService<IBookingContainer> BookingDeleteService { get; }
        private IMapper Mapper { get; }

        public BookingController(ILogger<BookingController> logger,
            IGetService<IBookingContainer, DomainBooking> bookingGetService,
            IUpdateService<BookingUpdateModel, IBookingContainer, DomainBooking> bookingUpdateService,
            ICreateService<BookingUpdateModel, IBookingContainer, DomainBooking> bookingCreateService,
            IDeleteService<IBookingContainer> bookingDeleteService, IMapper mapper) {
            Logger = logger;
            BookingGetService = bookingGetService;
            BookingUpdateService = bookingUpdateService;
            BookingCreateService = bookingCreateService;
            BookingDeleteService = bookingDeleteService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<BookingDTO>> GetAsync() {
            this.Logger.LogTrace($"{nameof(GetAsync)} called");
            var res = await BookingGetService.GetAsync();

            return Mapper.Map<IEnumerable<BookingDTO>>(res);
        }

        [HttpGet]
        [Route("{bookingId}")]
        public async Task<BookingDTO> GetAsync(int bookingId) {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {bookingId}");
            return this.Mapper.Map<BookingDTO>(
                await this.BookingGetService.GetAsync(new BookingIdentityModel(bookingId)));
        }

        [HttpPut]
        [Route("")]
        public async Task<BookingDTO> PutAsync(BookingCreateDTO dto) {
            this.Logger.LogTrace($"{nameof(BookingCreateService)} called for room with id = {dto.RoomId}");

            return this.Mapper.Map<BookingDTO>(
                await this.BookingCreateService.CreateAsync(Mapper.Map<BookingUpdateModel>(dto)));
        }

        [HttpPatch]
        [Route("")]
        public async Task<BookingDTO> PatchAsync(BookingUpdateDTO dto) {
            this.Logger.LogTrace($"{nameof(BookingUpdateService)} called for client with id = {dto.ClientId}");

            return this.Mapper.Map<BookingDTO>(
                await this.BookingUpdateService.UpdateAsync(Mapper.Map<BookingUpdateModel>(dto)));
        }

        [HttpDelete]
        [Route("{bookingId}")]
        public async Task DeleteAsync(int bookingId) {
            this.Logger.LogTrace($"{nameof(BookingDeleteService)} called for {bookingId}");
            await BookingDeleteService.DeleteAsync(new BookingIdentityModel(bookingId));
        }
    }
}