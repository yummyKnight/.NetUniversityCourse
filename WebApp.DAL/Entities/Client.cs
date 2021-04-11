using System;
using System.Collections.Generic;

#nullable disable

namespace WebApp.DAL.Entities
{
    public partial class Client
    {
        public Client()
        {
            Bookings = new HashSet<Booking>();
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public int? OrdersNum { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
