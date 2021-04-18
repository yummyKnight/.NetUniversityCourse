using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.BLL.Contracts;
using WebApp.Domain.Contracts;
using WebApp.Domain.Models;
using WebApp.DTO.Read;
using WebApp.DTO.Request;
using EntityRoom = WebApp.DAL.Entities.Room;
using DomainRoom = WebApp.Domain.Room;
using IRoomRep =
    WebApp.DAL.IRepository<WebApp.Domain.Room, WebApp.Domain.Contracts.IRoomContainer,
        WebApp.Domain.Models.RoomUpdateModel>;

namespace WebApp.WebAPI.Controllers {
    [ApiController]
    [Route("api/room")]
    public class RoomController : ControllerBase {
        private ILogger<RoomController> Logger { get; }
        private IGetService<IRoomContainer, DomainRoom> RoomGetService { get; }

        private IUpdateService<RoomUpdateModel, IRoomContainer, DomainRoom>
            RoomUpdateService { get; }

        private ICreateService<RoomUpdateModel, IRoomContainer, DomainRoom>
            RoomCreateService { get; }

        private IDeleteService<IRoomContainer> RoomDeleteService { get; }
        private IMapper Mapper { get; }


        public RoomController(ILogger<RoomController> logger, IGetService<IRoomContainer, DomainRoom> roomGetService,
            IUpdateService<RoomUpdateModel, IRoomContainer, DomainRoom> roomUpdateService,
            ICreateService<RoomUpdateModel, IRoomContainer, DomainRoom> roomCreateService,
            IDeleteService<IRoomContainer> roomDeleteService, IMapper mapper) {
            Logger = logger;
            RoomGetService = roomGetService;
            RoomUpdateService = roomUpdateService;
            RoomCreateService = roomCreateService;
            RoomDeleteService = roomDeleteService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<RoomDTO>> GetAsync() {
            this.Logger.LogDebug($"{nameof(GetAsync)} called");
            var res = await RoomGetService.GetAsync();

            return Mapper.Map<IEnumerable<RoomDTO>>(res);
        }

        [HttpGet]
        [Route("{roomId}")]
        public async Task<RoomDTO> GetAsync(int roomId) {
            this.Logger.LogDebug($"{nameof(this.GetAsync)} called for {roomId}");

            return this.Mapper.Map<RoomDTO>(
                await this.RoomGetService.GetAsync(new RoomIdentityModel(roomId)));
        }

        [HttpPut]
        [Route("")]
        public async Task<RoomDTO> PutAsync(RoomCreateDTO dto) {
            this.Logger.LogDebug($"{nameof(RoomCreateService)} called");

            return this.Mapper.Map<RoomDTO>(
                await this.RoomCreateService.CreateAsync(Mapper.Map<RoomUpdateModel>(dto)));
        }

        [HttpPatch]
        [Route("")]
        public async Task<RoomDTO> PatchAsync(RoomUpdateDTO dto) {
            this.Logger.LogDebug($"{nameof(RoomUpdateService)} called for {dto.RoomId}");

            return this.Mapper.Map<RoomDTO>(
                await this.RoomUpdateService.UpdateAsync(Mapper.Map<RoomUpdateModel>(dto)));
        }

        [HttpDelete]
        [Route("{roomId}")]
        public async Task DeleteAsync(int roomId) {
            this.Logger.LogDebug($"{nameof(RoomDeleteService)} called for {roomId}");
            await RoomDeleteService.DeleteAsync(new RoomIdentityModel(roomId));
        }
    }
}