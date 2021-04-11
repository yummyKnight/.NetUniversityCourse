using System.Collections.Generic;

#nullable disable

namespace WebApp.DAL.Entities
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public int? RoomTypeId { get; set; }
        public int Price { get; set; }

        public virtual RoomType RoomType { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
