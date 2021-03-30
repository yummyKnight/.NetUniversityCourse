using WebApp.Domain.Contracts;

namespace WebApp.Domain.Models {
    public class RoomTypeIdentityModel : IRoomTypeContainer {
        public int? RoomTypeId { get; }

        public RoomTypeIdentityModel(int id) {
            RoomTypeId = id;
        }
    }
}