﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Entities;
using WebApp.Domain;
using WebApp.Domain.Contracts;
using WebApp.Domain.Models;
using PaymentEntity = WebApp.DAL.Entities.Payment;
using PaymentDomain = WebApp.Domain.Payment;

namespace WebApp.DAL {
    public class PaymentRepository : IRepository<PaymentDomain, IPaymentContainer, PaymentUpdateModel> {
        private HotelDBContext Context;
        private IMapper Mapper { get; }

        public PaymentRepository(HotelDBContext context, IMapper mapper) {
            Context = context;
            Mapper = mapper;
        }

        public async Task<IEnumerable<PaymentDomain>> GetByAsync() {
            return Mapper.Map<IEnumerable<PaymentDomain>>(
                await Context.Payments.Include(x => x.Client)
                    .Include(x => x.PaymentType).ToListAsync());
        }

        public async Task<PaymentDomain> CreateAsync(PaymentUpdateModel model) {
            var result = await Context.Payments.AddAsync(Mapper.Map<PaymentEntity>(model));
            await Context.SaveChangesAsync();
            return Mapper.Map<PaymentDomain>(result.Entity);
        }

        public async Task<PaymentDomain> UpdateAsync(PaymentUpdateModel model) {
            var existing = await Get(model);
            Context.Entry(existing).State = EntityState.Modified;
            var result = Mapper.Map(model, existing);
            Context.Update(result);
            await Context.SaveChangesAsync();
            return Mapper.Map<PaymentDomain>(result);
        }

        public Task DeleteAsync(IPaymentContainer model) {
            throw new NotImplementedException();
        }

        public async Task<PaymentDomain> GetByAsync(IPaymentContainer model) {
            var res = await Get(model);
            return Mapper.Map<PaymentDomain>(res);
        }

        private async Task<PaymentEntity> Get(IPaymentContainer payment) {
            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment));
            }

            if (payment.PaymentId.HasValue)
                return await this.Context.Payments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == payment.PaymentId);
            return null;
        }
    }
}