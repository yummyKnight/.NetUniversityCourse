using System;
using WebApp.BLL.Contracts;
using WebApp.Domain;

namespace WebApp.BLL.Implementations {
    public class ClientBll : IClient {
        public Client Create(string name, string address) {
            throw new NotImplementedException();
        }

        public Client GetById(Guid id) {
            throw new NotImplementedException();
        }
    }
}