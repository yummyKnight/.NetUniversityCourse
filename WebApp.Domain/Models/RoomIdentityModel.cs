using WebApp.Domain.Contracts;

namespace WebApp.Domain.Models {
    public class RoomIdentityModel : IRoomContainer {
        public int? RoomId { get; }

        public RoomIdentityModel(int id) {
            RoomId = id;
        }
    }
}