using WebApp.Domain.Base;
using WebApp.Domain.Contracts;

namespace WebApp.Domain.Models {
    public class RoomUpdateModel : BaseRoom, IRoomContainer, IRoomTypeContainer {
        public int? RoomId { get; set; }
        public int? RoomTypeId { get; set; }
    }
}