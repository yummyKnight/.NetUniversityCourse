using System;

namespace WebApp.Domain {
    public class Client {
        public Client(uint id) {
            Id = id;
        }

        public uint Id { get; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public uint OrdersNum { get; set; }
    }
}