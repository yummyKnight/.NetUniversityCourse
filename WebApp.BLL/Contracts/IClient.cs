using System;
using WebApp.Domain;
namespace WebApp.BLL.Contracts {
    public interface IClient {
        Client Create(string name, string address);
        Client GetById(Guid id);
    }
}