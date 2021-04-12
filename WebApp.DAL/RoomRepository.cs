using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Entities;
using WebApp.Domain.Contracts;
using WebApp.Domain.Models;
using EntityRoom = WebApp.DAL.Entities.Room;
using DomainRoom = WebApp.Domain.Room;
using IRoomRep =
    WebApp.DAL.IRepository<WebApp.Domain.Room, WebApp.Domain.Contracts.IRoomContainer,
        WebApp.Domain.Models.RoomUpdateModel>;

namespace WebApp.DAL {
    public class RoomRepository : IRoomRep {
        private HotelDBContext Context { get; }
        private IMapper Mapper { get; }

        public RoomRepository(HotelDBContext context, IMapper mapper) {
            Context = context;
            Mapper = mapper;
        }

        // TODO: add Include
        public async Task<IEnumerable<DomainRoom>> GetByAsync() {
            return this.Mapper.Map<IEnumerable<DomainRoom>>(
                await this.Context.Rooms.AsNoTracking().ToListAsync());
        }

        public async Task<DomainRoom> GetByAsync(IRoomContainer model) {
            var res = await Get(model);
            return Mapper.Map<DomainRoom>(res);
        }

        public async Task<DomainRoom> CreateAsync(RoomUpdateModel model) {
            var result = await Context.Rooms.AddAsync(Mapper.Map<EntityRoom>(model));
            await Context.SaveChangesAsync();
            return Mapper.Map<DomainRoom>(result.Entity);
        }

        public async Task<DomainRoom> UpdateAsync(RoomUpdateModel model) {
            var existing = await Get(model);
            Context.Entry(existing).State = EntityState.Modified;
            var result = Mapper.Map(model, existing);
            Context.Update(result);
            await Context.SaveChangesAsync();
            return Mapper.Map<DomainRoom>(result);
        }

        public async Task DeleteAsync(IRoomContainer model) {
            Context.Rooms.Remove(Mapper.Map<EntityRoom>(model));
            await Context.SaveChangesAsync();
        }

        // TODO: add Include
        private async Task<EntityRoom> Get(IRoomContainer room) {
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room));
            }

            if (room.RoomId.HasValue)
                return await this.Context.Rooms.AsNoTracking().FirstOrDefaultAsync(x => x.Id == room.RoomId);
            return null;
        }
    }
}