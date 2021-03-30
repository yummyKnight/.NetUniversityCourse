using System;
using WebApp.Domain.Base;

namespace WebApp.Domain {
    public class Client : BaseClient{
        public Client(int id) {
            Id = id;
        }

        public int Id { get; }

    }
}