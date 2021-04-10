using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.BLL.Contracts;
using WebApp.DAL;
using WebApp.Domain;
using WebApp.Domain.Contracts;
using WebApp.Domain.Models;

namespace WebApp.BLL.Implementations {
    public class ClientGetService : IClientGetService {
        private IClientRepository _repository;

        public ClientGetService(IClientRepository repository) {
            _repository = repository;
        }

        public async Task<IEnumerable<Client>> GetAsync() {
            return await _repository.GetByAsync();
        }

        public async Task<Client> GetAsync(IClientContainer client) {
            // await ValidateAsync(client);
            return await _repository.GetByAsync(client);
        }

        public async Task ValidateAsync(IClientContainer model, bool isTracked=false) {
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
    }

    public class ClientUpdateService : IUpdateService<ClientUpdateModel, Domain.Client> {
        private IClientRepository _repository;
        private IClientGetService _service;

        public ClientUpdateService(IClientRepository repository, IClientGetService service) {
            _repository = repository;
            _service = service;
        }

        public async Task<Client> UpdateAsync(ClientUpdateModel model) {
            await _service.ValidateAsync(model, false);
            return await _repository.UpdateAsync(model);
        }
    }

    public class ClientCreateService : ICreateService<ClientUpdateModel, Domain.Client> {
        private IClientRepository _repository;

        public ClientCreateService(IClientRepository repository) {
            _repository = repository;
        }

        public async Task<Client> CreateAsync(ClientUpdateModel model) {
            return await _repository.CreateAsync(model);
        }
    }

    public class ClientDeleteService : IDeleteService<IClientContainer> {
        private IClientRepository _repository { get; }
        private IClientGetService _service { get; }

        public ClientDeleteService(IClientRepository repository, IClientGetService service) {
            _repository = repository;
            _service = service;
        }

        public async Task DeleteAsync(IClientContainer model) {
            await _service.ValidateAsync(model, false);
            await _repository.DeleteAsync(model);
        }
    }
}