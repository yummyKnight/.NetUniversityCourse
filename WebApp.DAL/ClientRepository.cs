using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Entities;
using WebApp.Domain;
using WebApp.Domain.Contracts;
using WebApp.Domain.Models;
using Client = WebApp.DAL.Entities.Client;

namespace WebApp.DAL {
    public class ClientRepository : IClientRepository {
        private HotelDBContext Context { get; }
        private IMapper Mapper { get; }

        public ClientRepository(HotelDBContext context, IMapper mapper) {
            Context = context;
            Mapper = mapper;
        }

        private async Task<Client> Get(IClientContainer client) {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            if (client.ClientId.HasValue)
                return await this.Context.Clients.AsNoTracking().FirstOrDefaultAsync(x => x.Id == client.ClientId);
            return null;
        }

        public async Task<IEnumerable<Domain.Client>> GetByAsync() {
            return this.Mapper.Map<IEnumerable<Domain.Client>>(
                await this.Context.Clients.AsNoTracking().ToListAsync());
        }

        public async Task<Domain.Client> GetByAsync(IClientContainer model) {
            var res = await Get(model);
            return Mapper.Map<Domain.Client>(res);
        }

        public async Task<Domain.Client> CreateAsync(ClientUpdateModel model) {
            var result = await Context.Clients.AddAsync(Mapper.Map<Client>(model));
            await Context.SaveChangesAsync();
            return Mapper.Map<Domain.Client>(result.Entity);
        }

        public async Task<Domain.Client> UpdateAsync(ClientUpdateModel model) {
            var existing = await Get(model);
            Context.Entry(existing).State = EntityState.Modified;
            var result = Mapper.Map(model, existing);
            Context.Update(result);
            await Context.SaveChangesAsync();
            return Mapper.Map<Domain.Client>(result);
        }

        public async Task DeleteAsync(IClientContainer model) {
            Context.Clients.Remove(Mapper.Map<Client>(model));
            await Context.SaveChangesAsync();
        }
    }
}