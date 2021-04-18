using System;
using System.Threading.Tasks;
using WebApp.BLL.Contracts;
using WebApp.Domain;
using WebApp.Domain.Contracts;
using WebApp.Domain.Models;
using EntityRoomType = WebApp.DAL.Entities.RoomType;
using DomainRoomType = WebApp.Domain.RoomType;
using IRoomTypeRep =
    WebApp.DAL.IRepository<WebApp.Domain.RoomType, WebApp.Domain.Contracts.IRoomTypeContainer,
        WebApp.Domain.Models.RoomTypeUpdateModel>;

namespace WebApp.BLL.Implementations {
    public class
        RoomTypeGetService : GenericGetService<IRoomTypeRep, RoomTypeUpdateModel, DomainRoomType, IRoomTypeContainer> {
        public override async Task ValidateAsync(IRoomTypeContainer model) {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var roomType = await GetAsync(model);

            if (model.RoomTypeId.HasValue && roomType == null)
            {
                throw new InvalidOperationException($"RoomType not found by id {model.RoomTypeId}");
            }
        }

        public RoomTypeGetService(IRoomTypeRep repository) : base(repository) {
        }
    }

    public class RoomTypeUpdateService : GenericUpdateService<IGetService<IRoomTypeContainer, DomainRoomType>,
        IRoomTypeRep,
        RoomTypeUpdateModel, DomainRoomType, IRoomTypeContainer> {
        public RoomTypeUpdateService(IRoomTypeRep repository, IGetService<IRoomTypeContainer, RoomType> getService) :
            base(repository, getService) {
        }
    }

    public class RoomTypeCreateService : GenericCreateService<IRoomTypeRep,
        RoomTypeUpdateModel, DomainRoomType, IRoomTypeContainer> {
        public RoomTypeCreateService(IRoomTypeRep repository) : base(repository) {
        }
    }

    public class RoomTypeDeleteService : GenericDeleteService<IGetService<IRoomTypeContainer, DomainRoomType>,
        IRoomTypeRep,
        RoomTypeUpdateModel, DomainRoomType, IRoomTypeContainer> {
        public RoomTypeDeleteService(IRoomTypeRep repository, IGetService<IRoomTypeContainer, RoomType> service) : base(
            repository, service) {
        }
    }
}