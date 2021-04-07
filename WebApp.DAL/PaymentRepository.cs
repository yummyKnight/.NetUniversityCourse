using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Entities;
using WebApp.Domain;
using WebApp.Domain.Models;

namespace WebApp.DAL {
    public class PaymentRepository : IRepository<Payment, PaymentIdentityModel, PaymentUpdateModel> {
        private HotelDBContext Context;
        private IMapper Mapper { get; }

        public PaymentRepository(HotelDBContext context, IMapper mapper) {
            Context = context;
            Mapper = mapper;
        }

        public async Task<IEnumerable<Payment>> GetByAsync() {
            return Mapper.Map<IEnumerable<Payment>>(
                await Context.Payments.Include(x => x.Client)
                    .Include(x => x.PaymentType).ToListAsync());
        }

        public  async Task<Payment> GetByAsync(PaymentIdentityModel model) {
            var res = await Get(model);
            return Mapper.Map<Payment>(res);
        }

        public Task<Payment> CreateAsync(PaymentUpdateModel model) {
            throw new NotImplementedException();
        }

        public Task<Payment> UpdateAsync(PaymentUpdateModel model) {
            throw new NotImplementedException();
        }

        public void DeleteAsync(PaymentIdentityModel model) {
            throw new NotImplementedException();
        }

        private async Task<Models.Payment> Get(PaymentIdentityModel client) {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            return await this.Context.Payments.FirstOrDefaultAsync(x => x.Id == client.PaymentId);
        }
    }
}