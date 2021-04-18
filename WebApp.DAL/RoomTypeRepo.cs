using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Entities;
using WebApp.Domain.Contracts;
using WebApp.Domain.Models;
using EntityRoomType = WebApp.DAL.Entities.RoomType;
using DomainRoomType = WebApp.Domain.RoomType;
using IRoomTypeRep =
    WebApp.DAL.IRepository<WebApp.Domain.RoomType, WebApp.Domain.Contracts.IRoomTypeContainer,
        WebApp.Domain.Models.RoomTypeUpdateModel>;

namespace WebApp.DAL {
    public class RoomTypeRepo : IRoomTypeRep {
        private HotelDbContext Context { get; }
        private IMapper Mapper { get; }

        public RoomTypeRepo(HotelDbContext context, IMapper mapper) {
            Context = context;
            Mapper = mapper;
        }

        // TODO: add Include
        public async Task<IEnumerable<DomainRoomType>> GetByAsync() {
            return this.Mapper.Map<IEnumerable<DomainRoomType>>(
                await this.Context.RoomTypes.AsNoTracking().ToListAsync());
        }

        public async Task<DomainRoomType> GetByAsync(IRoomTypeContainer model) {
            var res = await Get(model);
            return Mapper.Map<DomainRoomType>(res);
        }

        public async Task<DomainRoomType> CreateAsync(RoomTypeUpdateModel model) {
            var result = await Context.RoomTypes.AddAsync(Mapper.Map<EntityRoomType>(model));
            await Context.SaveChangesAsync();
            return Mapper.Map<DomainRoomType>(result.Entity);
        }

        public async Task<DomainRoomType> UpdateAsync(RoomTypeUpdateModel model) {
            var existing = await Get(model);
            Context.Entry(existing).State = EntityState.Modified;
            var result = Mapper.Map(model, existing);
            Context.Update(result);
            await Context.SaveChangesAsync();
            return Mapper.Map<DomainRoomType>(result);
        }

        public async Task DeleteAsync(IRoomTypeContainer model) {
            Context.RoomTypes.Remove(Mapper.Map<EntityRoomType>(model));
            await Context.SaveChangesAsync();
        }

        // TODO: add Include
        private async Task<EntityRoomType> Get(IRoomTypeContainer room) {
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room));
            }

            if (room.RoomTypeId.HasValue)
                return await this.Context.RoomTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == room.RoomTypeId);
            return null;
        }
    }
}