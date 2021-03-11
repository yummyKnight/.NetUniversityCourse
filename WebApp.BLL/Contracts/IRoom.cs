using System;
using WebApp.Domain;

namespace WebApp.BLL.Contracts {
    public interface IRoom {
        Room Create(RoomType type);
        Room GetById(Guid id);
    }
}