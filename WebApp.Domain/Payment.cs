using System;

namespace WebApp.Domain {
    public class Payment {
        public Payment(uint id) {
            Id = id;
        }

        public uint Id { get; }
        public Client Client { get; set; }
        public Booking Booking { get; set; }
        public PaymentType Type { get; set; }
        public uint Amount { get; set; }
        public bool? IsCanceled { get; set; }
        public DateTime CanceledAt { get; set; }
    }
}