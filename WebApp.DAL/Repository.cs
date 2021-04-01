using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Entities;
using WebApp.Domain;

namespace WebApp.DAL {
    class Repository<TDomainClass, TIdentityModel, TUpdateModel> : IRepository<TDomainClass, TIdentityModel,
        TUpdateModel> where TDomainClass : class where TIdentityModel : class where TUpdateModel : class {
        private HotelDBContext Context { get; }
        private IMapper Mapper { get; }

        public Repository(HotelDBContext context, IMapper mapper) {
            Context = context;
            Mapper = mapper;
        }

        public async Task<IEnumerable<TDomainClass>> GetByAsync() {
            return Mapper.Map<IEnumerable<TDomainClass>>(
                await this.Context.Bookings.Include(x => x.Client).ToListAsync());
        }

        public Task<TDomainClass> GetByAsync(TIdentityModel model) {
            throw new NotImplementedException();
        }

        public Task<TDomainClass> CreateAsync(TUpdateModel model) {
            throw new NotImplementedException();
        }

        public Task<TDomainClass> UpdateAsync(TUpdateModel model) {
            throw new NotImplementedException();
        }

        public void DeleteAsync(TIdentityModel model) {
            throw new NotImplementedException();
        }
    }
}