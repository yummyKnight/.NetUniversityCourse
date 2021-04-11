using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.Domain;
using WebApp.Domain.Contracts;
using WebApp.Domain.Models;
using WebApp.DAL.Entities;
using EntityBooking = WebApp.DAL.Entities.Booking;
using DomainBooking = WebApp.Domain.Booking;
using IBookingRep =
    WebApp.DAL.IRepository<WebApp.Domain.Booking, WebApp.Domain.Contracts.IBookingContainer,
        WebApp.Domain.Models.BookingUpdateModel>;

namespace WebApp.DAL {
    public class BookingRepository : IBookingRep {
        private HotelDBContext Context { get; }
        private IMapper Mapper { get; }

        public BookingRepository(HotelDBContext context, IMapper mapper) {
            Context = context;
            Mapper = mapper;
        }

        private async Task<EntityBooking> Get(IBookingContainer client) {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            if (client.BookingId.HasValue)
                return await this.Context.Bookings.AsNoTracking().FirstOrDefaultAsync(x => x.Id == client.BookingId);
            return null;
        }

        public async Task<IEnumerable<DomainBooking>> GetByAsync() {
            return this.Mapper.Map<IEnumerable<DomainBooking>>(
                await this.Context.Bookings.AsNoTracking().ToListAsync());
        }

        public async Task<DomainBooking> GetByAsync(IBookingContainer model) {
            var res = await Get(model);
            return Mapper.Map<DomainBooking>(res);
        }

        public async Task<DomainBooking> CreateAsync(BookingUpdateModel model) {
            var result = await Context.Bookings.AddAsync(Mapper.Map<EntityBooking>(model));
            await Context.SaveChangesAsync();
            return Mapper.Map<DomainBooking>(result.Entity);
        }

        public async Task<DomainBooking> UpdateAsync(BookingUpdateModel model) {
            var existing = await Get(model);
            Context.Entry(existing).State = EntityState.Modified;
            var result = Mapper.Map(model, existing);
            Context.Update(result);
            await Context.SaveChangesAsync();
            return Mapper.Map<DomainBooking>(result);
        }

        public async Task DeleteAsync(IBookingContainer model) {
            Context.Bookings.Remove(Mapper.Map<EntityBooking>(model));
            await Context.SaveChangesAsync();
        }
    }
}