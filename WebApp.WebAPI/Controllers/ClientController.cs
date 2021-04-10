using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.BLL.Contracts;
using WebApp.BLL.Implementations;
using WebApp.DAL.Entities;
using WebApp.DAL.Models;
using WebApp.Domain.Contracts;
using WebApp.Domain.Models;
using WebApp.DTO.Read;
using WebApp.DTO.Request;
using Client = WebApp.Domain.Client;

namespace WebAPI.Controllers {
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase {
        private ILogger<ClientController> Logger { get; }
        private IClientGetService ClientGetService { get; }
        private IUpdateService<ClientUpdateModel, WebApp.Domain.Client> ClientUpdateService { get; }
        private ICreateService<ClientUpdateModel, WebApp.Domain.Client> ClientCreateService { get; }
        private IDeleteService<IClientContainer> ClientDeleteService { get; }
        private IMapper Mapper { get; }

        public ClientController(ILogger<ClientController> logger, IClientGetService clientGetService,
            IUpdateService<ClientUpdateModel, Client> clientUpdateService,
            ICreateService<ClientUpdateModel, Client> clientCreateService,
            IDeleteService<IClientContainer> clientDeleteService, IMapper mapper) {
            Logger = logger;
            ClientGetService = clientGetService;
            ClientUpdateService = clientUpdateService;
            ClientCreateService = clientCreateService;
            ClientDeleteService = clientDeleteService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ClientDTO>> GetAsync() {
            this.Logger.LogTrace($"{nameof(GetAsync)} called");
            var res = await ClientGetService.GetAsync();

            return Mapper.Map<IEnumerable<ClientDTO>>(res);
        }

        [HttpGet]
        [Route("{clientId}")]
        public async Task<ClientDTO> GetAsync(int clientId) {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {clientId}");

            return this.Mapper.Map<ClientDTO>(await this.ClientGetService.GetAsync(new ClientIdentityModel(clientId)));
        }

        [HttpPut]
        [Route("")]
        public async Task<ClientDTO> PutAsync(ClientCreateDTO dto) {
            this.Logger.LogTrace($"{nameof(ClientCreateService)} called for {dto.FullName}");

            return this.Mapper.Map<ClientDTO>(
                await this.ClientCreateService.CreateAsync(Mapper.Map<ClientUpdateModel>(dto)));
        }

        [HttpPatch]
        [Route("")]
        public async Task<ClientDTO> PatchAsync(ClientUpdateDTO dto) {
            this.Logger.LogTrace($"{nameof(ClientUpdateService)} called for {dto.ClientId}");

            return this.Mapper.Map<ClientDTO>(
                await this.ClientUpdateService.UpdateAsync(Mapper.Map<ClientUpdateModel>(dto)));
        }

        [HttpDelete]
        [Route("{clientId}")]
        public async Task DeleteAsync(int clientId) {
            this.Logger.LogTrace($"{nameof(ClientDeleteService)} called for {clientId}");
            await ClientDeleteService.DeleteAsync(new ClientIdentityModel(clientId));
        }
    }
}
// .ForMember("Id",
//     opt => opt.MapFrom(c => c.ClientId));