using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.BLL.Contracts;
using WebApp.DAL;
using WebApp.Domain;
using WebApp.Domain.Contracts;
using WebApp.Domain.Models;

namespace WebApp.BLL.Implementations {
    public class
        ClientGetService : GenericGetService<IClientRepository, ClientUpdateModel, Domain.Client, IClientContainer> {
        public override async Task ValidateAsync(IClientContainer model) {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var client = await GetAsync(model);

            if (model.ClientId.HasValue && client == null)
            {
                throw new InvalidOperationException($"Client not found by id {model.ClientId}");
            }
        }

        public ClientGetService(IClientRepository repository) : base(repository) {
        }
    }

    public class ClientUpdateService : GenericUpdateService<IGetService<IClientContainer, Client>, IClientRepository,
        ClientUpdateModel, Client, IClientContainer> {
        public ClientUpdateService(IClientRepository repository, IGetService<IClientContainer, Client> getService) :
            base(repository, getService) {
        }
    }

    public class ClientCreateService : GenericCreateService<IClientRepository,
        ClientUpdateModel, Client, IClientContainer> {
        public ClientCreateService(IClientRepository repository) : base(repository) {
        }
    }

    public class ClientDeleteService : GenericDeleteService<IGetService<IClientContainer, Client>, IClientRepository,
        ClientUpdateModel, Client, IClientContainer> {
        public ClientDeleteService(IClientRepository repository, IGetService<IClientContainer, Client> service) : base(
            repository, service) {
        }
    }
}