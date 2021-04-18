using System;
using System.Threading.Tasks;
using WebApp.BLL.Contracts;
using WebApp.Domain;
using WebApp.Domain.Contracts;
using WebApp.Domain.Models;
using EntityRoom = WebApp.DAL.Entities.Room;
using DomainRoom = WebApp.Domain.Room;
using IRoomRep =
    WebApp.DAL.IRepository<WebApp.Domain.Room, WebApp.Domain.Contracts.IRoomContainer,
        WebApp.Domain.Models.RoomUpdateModel>;

namespace WebApp.BLL.Implementations {
    public class RoomGetService : GenericGetService<IRoomRep, RoomUpdateModel, DomainRoom, IRoomContainer> {
        public override async Task ValidateAsync(IRoomContainer model) {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var client = await GetAsync(model);

            if (model.RoomId.HasValue && client == null)
            {
                throw new InvalidOperationException($"Room not found by id {model.RoomId}");
            }
        }

        public RoomGetService(IRoomRep repository) : base(repository) {
        }
    }

    public class RoomUpdateService : IUpdateService<RoomUpdateModel, IRoomContainer, DomainRoom> {
        private IRoomRep _repository;
        private IGetService<IRoomContainer, Room> _roomGetService;
        private IGetService<IRoomTypeContainer, RoomType> _typeRepoGetService;


        public RoomUpdateService(IRoomRep repository, IGetService<IRoomContainer, Room> roomGetService,
            IGetService<IRoomTypeContainer, RoomType> typeRepoGetService) {
            _repository = repository;
            _roomGetService = roomGetService;
            _typeRepoGetService = typeRepoGetService;
        }

        public async Task<Room> UpdateAsync(RoomUpdateModel model) {
            await _typeRepoGetService.ValidateAsync(model);
            await _roomGetService.ValidateAsync(model);
            return await _repository.UpdateAsync(model);
        }
    }

    public class RoomCreateService : ICreateService<RoomUpdateModel, IRoomContainer, DomainRoom> {
        private IRoomRep _repository;
        private IGetService<IRoomTypeContainer, RoomType> _typeRepoGetService;

        public RoomCreateService(IRoomRep repository, IGetService<IRoomTypeContainer, RoomType> typeRepoGetService) {
            _repository = repository;
            _typeRepoGetService = typeRepoGetService;
        }

        public async Task<Room> CreateAsync(RoomUpdateModel model) {
            await _typeRepoGetService.ValidateAsync(model);
            return await _repository.CreateAsync(model);
        }
    }

    public class RoomDeleteService : IDeleteService<IRoomContainer> {
        private IRoomRep _repository;
        private IGetService<IRoomContainer, Room> _roomGetService;

        public RoomDeleteService(IRoomRep repository, IGetService<IRoomContainer, Room> roomGetService) {
            _repository = repository;
            _roomGetService = roomGetService;
        }

        public async Task DeleteAsync(IRoomContainer model) {
            await _roomGetService.ValidateAsync(model);
            await _repository.DeleteAsync(model);
        }
    }
}