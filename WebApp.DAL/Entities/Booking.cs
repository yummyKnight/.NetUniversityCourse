using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.DAL.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? RoomId { get; set; }
        public DateTime ReservedDay { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool? IsCanceled { get; set; }
        public DateTime? CanceledAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual Client Client { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
