using System;

#nullable disable

namespace WebApp.DAL.Entities
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? BookingId { get; set; }
        public int Amount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? PaymentTypeId { get; set; }
        public bool? Canceled { get; set; }
        public DateTime? CanceledAt { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Client Client { get; set; }
        public virtual PaymentType PaymentType { get; set; }
    }
}
