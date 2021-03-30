using System;
using WebApp.Domain.Base;

namespace WebApp.Domain {
    public class Payment : BasePayment {
        public Payment(uint id) {
            Id = id;
        }

        public uint Id { get; }
    }
}