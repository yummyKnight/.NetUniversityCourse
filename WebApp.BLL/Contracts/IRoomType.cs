using System;
using WebApp.Domain;

namespace WebApp.BLL.Contracts {
    public interface IRoomType {
        RoomType Create(string roomType);
        RoomType GetById(Guid id);
    }
}