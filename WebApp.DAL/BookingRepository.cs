using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Entities;
using WebApp.Domain;
using WebApp.Domain.Models;

namespace WebApp.DAL {
    public class BookingRepository : IRepository<Booking, BookingIdentityModel, BookingUpdateModel> {
        private HotelDBContext Context;
        private IMapper Mapper { get; }

        public BookingRepository(HotelDBContext context, IMapper mapper) {
            Context = context;
            Mapper = mapper;
        }

        public async Task<IEnumerable<Booking>> GetByAsync() {
            return this.Mapper.Map<IEnumerable<Booking>>(
                await this.Context.Bookings.ToListAsync());
        }

        public async Task<Booking> GetByAsync(BookingIdentityModel model) {
            var res = await Get(model);
            return Mapper.Map<Booking>(res);
        }

        public Task<Booking> CreateAsync(BookingUpdateModel model) {
            throw new System.NotImplementedException();
        }

        public Task<Booking> UpdateAsync(BookingUpdateModel model) {
            throw new System.NotImplementedException();
        }

        public void DeleteAsync(BookingIdentityModel model) {
            throw new System.NotImplementedException();
        }

        private async Task<Models.Booking> Get(BookingIdentityModel client) {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            return await Context.Bookings.FirstOrDefaultAsync(x => x.Id == client.BookingId);
        }
    }
}