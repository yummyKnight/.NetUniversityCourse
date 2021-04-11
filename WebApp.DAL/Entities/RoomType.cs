using System.Collections.Generic;

#nullable disable

namespace WebApp.DAL.Entities
{
    public partial class RoomType
    {
        public RoomType()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string RoomType1 { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
