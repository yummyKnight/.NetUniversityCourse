using WebApp.Domain.Contracts;

namespace WebApp.Domain.Models {
    public class ClientIdentityModel : IClientContainer {
        public int? ClientId { get; }

        public ClientIdentityModel(int id) {
            ClientId = id;
        }
    }
}