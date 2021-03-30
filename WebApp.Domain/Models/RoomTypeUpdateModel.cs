using WebApp.Domain.Base;
using WebApp.Domain.Contracts;

namespace WebApp.Domain.Models {
    public class RoomTypeUpdateModel : BaseRoomType, IRoomTypeContainer {
        public int? RoomTypeId { get; set;}
    }
}