using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Entities;
using WebApp.Domain;
using WebApp.Domain.Models;

namespace WebApp.DAL {
    public class ClientRepository : IRepository<Client, ClientIdentityModel, ClientUpdateModel> {
        private HotelDBContext Context;
        private IMapper Mapper { get; }


        private async Task<Models.Client> Get(ClientIdentityModel client) {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            return await this.Context.Clients.FirstOrDefaultAsync(x => x.Id == client.ClientId);
        }

        public async Task<IEnumerable<Client>> GetByAsync() {
            return this.Mapper.Map<IEnumerable<Client>>(
                await this.Context.Clients.ToListAsync());
        }

        public async Task<Client> GetByAsync(ClientIdentityModel model) {
            var res = await Get(model);
            return Mapper.Map<Client>(res);
        }

        public Task<Client> CreateAsync(ClientUpdateModel model) {
            throw new System.NotImplementedException();
        }

        public Task<Client> UpdateAsync(ClientUpdateModel model) {
            throw new System.NotImplementedException();
        }

        public void DeleteAsync(ClientIdentityModel model) {
            throw new System.NotImplementedException();
        }
    }
}