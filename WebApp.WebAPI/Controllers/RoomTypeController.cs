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
using EntityRoomType = WebApp.DAL.Entities.RoomType;
using DomainRoomType = WebApp.Domain.RoomType;
using IRoomTypeRep =
    WebApp.DAL.IRepository<WebApp.Domain.RoomType, WebApp.Domain.Contracts.IRoomTypeContainer,
        WebApp.Domain.Models.RoomTypeUpdateModel>;

namespace WebApp.WebAPI.Controllers {
    [ApiController]
    [Route("api/roomtype")]
    public class RoomTypeController : Controller {
        private ILogger<RoomTypeController> Logger { get; }
        private IGetService<IRoomTypeContainer, DomainRoomType> RoomTypeGetService { get; }

        private IUpdateService<RoomTypeUpdateModel, IRoomTypeContainer, DomainRoomType>
            RoomTypeUpdateService { get; }

        private ICreateService<RoomTypeUpdateModel, IRoomTypeContainer, DomainRoomType>
            RoomTypeCreateService { get; }

        private IDeleteService<IRoomTypeContainer> RoomTypeDeleteService { get; }
        private IMapper Mapper { get; }


        public RoomTypeController(ILogger<RoomTypeController> logger,
            IGetService<IRoomTypeContainer, DomainRoomType> roomTypeGetService,
            IUpdateService<RoomTypeUpdateModel, IRoomTypeContainer, DomainRoomType> roomTypeUpdateService,
            ICreateService<RoomTypeUpdateModel, IRoomTypeContainer, DomainRoomType> roomTypeCreateService,
            IDeleteService<IRoomTypeContainer> roomTypeDeleteService, IMapper mapper) {
            Logger = logger;
            RoomTypeGetService = roomTypeGetService;
            RoomTypeUpdateService = roomTypeUpdateService;
            RoomTypeCreateService = roomTypeCreateService;
            RoomTypeDeleteService = roomTypeDeleteService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<RoomTypeDTO>> GetAsync() {
            this.Logger.LogDebug($"{nameof(GetAsync)} called");
            var res = await RoomTypeGetService.GetAsync();

            return Mapper.Map<IEnumerable<RoomTypeDTO>>(res);
        }

        [HttpGet]
        [Route("{RoomTypeId}")]
        public async Task<RoomTypeDTO> GetAsync(int RoomTypeId) {
            this.Logger.LogDebug($"{nameof(this.GetAsync)} called for {RoomTypeId}");

            return this.Mapper.Map<RoomTypeDTO>(
                await this.RoomTypeGetService.GetAsync(new RoomTypeIdentityModel(RoomTypeId)));
        }

        [HttpPut]
        [Route("")]
        public async Task<RoomTypeDTO> PutAsync(RoomTypeCreateDTO dto) {
            this.Logger.LogDebug($"{nameof(RoomTypeCreateService)} called");

            return this.Mapper.Map<RoomTypeDTO>(
                await this.RoomTypeCreateService.CreateAsync(Mapper.Map<RoomTypeUpdateModel>(dto)));
        }

        [HttpPatch]
        [Route("")]
        public async Task<RoomTypeDTO> PatchAsync(RoomTypeUpdateDTO dto) {
            this.Logger.LogDebug($"{nameof(RoomTypeUpdateService)} called for {dto.RoomId}");

            return this.Mapper.Map<RoomTypeDTO>(
                await this.RoomTypeUpdateService.UpdateAsync(Mapper.Map<RoomTypeUpdateModel>(dto)));
        }

        [HttpDelete]
        [Route("{RoomTypeId}")]
        public async Task DeleteAsync(int roomTypeId) {
            this.Logger.LogDebug($"{nameof(RoomTypeDeleteService)} called for {roomTypeId}");
            await RoomTypeDeleteService.DeleteAsync(new RoomTypeIdentityModel(roomTypeId));
        }
    }
}