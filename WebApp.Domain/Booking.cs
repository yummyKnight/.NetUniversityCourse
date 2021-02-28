using System;

namespace WebApp.Domain {
    public class Booking {
        public Booking(uint id) {
            Id = id;
        }

        public uint Id { get; }
        public Client Client { get; set; }
        public Room Room { get; set; }
        public DateTime ReservedDay { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool? IsCanceled { get; set; }
        public DateTime CanceledAt { get; set; }
    }
}