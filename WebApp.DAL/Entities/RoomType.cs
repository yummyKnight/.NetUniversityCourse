using System;
using System.Collections.Generic;
using WebApp.DAL.Entities;

#nullable disable

namespace WebApp.DAL.Models
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
