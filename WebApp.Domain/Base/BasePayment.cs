using System;

namespace WebApp.Domain.Base {
    public class BasePayment {
        public Booking Booking { get; set; }
        public PaymentType Type { get; set; }
        public uint Amount { get; set; }
        public bool? IsCanceled { get; set; }
        public DateTime CanceledAt { get; set; }
    }
}