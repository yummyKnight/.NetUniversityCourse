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

    public class RoomUpdateService : GenericUpdateService<IGetService<IRoomContainer, DomainRoom>, IRoomRep,
        RoomUpdateModel, DomainRoom, IRoomContainer> {
        public RoomUpdateService(IRoomRep repository, IGetService<IRoomContainer, DomainRoom> getService) : base(
            repository, getService) {
        }
    }

    public class RoomCreateService : GenericCreateService<IRoomRep,
        RoomUpdateModel, DomainRoom, IRoomContainer> {
        public RoomCreateService(IRoomRep repository) : base(repository) {
        }
    }

    public class RoomDeleteService : GenericDeleteService<IGetService<IRoomContainer, DomainRoom>, IRoomRep,
        RoomUpdateModel, DomainRoom, IRoomContainer> {
        public RoomDeleteService(IRoomRep repository, IGetService<IRoomContainer, Room> service) : base(repository,
            service) {
        }
    }
}