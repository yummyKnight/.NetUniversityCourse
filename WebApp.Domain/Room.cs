using WebApp.Domain.Base;

namespace WebApp.Domain {
    public class Room : BaseRoom {
        public uint Id { get; }

        public Room(uint id) {
            Id = id;
        }
    }
}