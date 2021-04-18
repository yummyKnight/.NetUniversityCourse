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
using EntityPayment = WebApp.DAL.Entities.Payment;
using DomainPayment = WebApp.Domain.Payment;
using IPaymentRep =
    WebApp.DAL.IRepository<WebApp.Domain.Payment, WebApp.Domain.Contracts.IPaymentContainer,
        WebApp.Domain.Models.PaymentUpdateModel>;

namespace WebApp.WebAPI.Controllers {
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase {
        private ILogger<PaymentController> Logger { get; }
        private IGetService<IPaymentContainer, DomainPayment> PaymentGetService { get; }

        private IUpdateService<PaymentUpdateModel, IPaymentContainer, DomainPayment>
            PaymentUpdateService { get; }

        private ICreateService<PaymentUpdateModel, IPaymentContainer, DomainPayment>
            PaymentCreateService { get; }

        private IDeleteService<IPaymentContainer> PaymentDeleteService { get; }
        private IMapper Mapper { get; }

        public PaymentController(ILogger<PaymentController> logger,
            IGetService<IPaymentContainer, DomainPayment> paymentGetService,
            IUpdateService<PaymentUpdateModel, IPaymentContainer, DomainPayment> paymentUpdateService,
            ICreateService<PaymentUpdateModel, IPaymentContainer, DomainPayment> paymentCreateService,
            IDeleteService<IPaymentContainer> paymentDeleteService, IMapper mapper) {
            Logger = logger;
            PaymentGetService = paymentGetService;
            PaymentUpdateService = paymentUpdateService;
            PaymentCreateService = paymentCreateService;
            PaymentDeleteService = paymentDeleteService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<PaymentDTO>> GetAsync() {
            this.Logger.LogDebug($"{nameof(GetAsync)} called");
            var res = await PaymentGetService.GetAsync();

            return Mapper.Map<IEnumerable<PaymentDTO>>(res);
        }

        [HttpGet]
        [Route("{paymentId}")]
        public async Task<PaymentDTO> GetAsync(int paymentId) {
            this.Logger.LogDebug($"{nameof(this.GetAsync)} called for {paymentId}");

            return this.Mapper.Map<PaymentDTO>(
                await this.PaymentGetService.GetAsync(new PaymentIdentityModel(paymentId)));
        }

        [HttpPut]
        [Route("")]
        public async Task<PaymentDTO> PutAsync(PaymentCreateDTO dto) {
            this.Logger.LogDebug($"{nameof(PaymentCreateService)} called booking with id = {dto.BookingId}");

            return this.Mapper.Map<PaymentDTO>(
                await this.PaymentCreateService.CreateAsync(Mapper.Map<PaymentUpdateModel>(dto)));
        }

        [HttpPatch]
        [Route("")]
        public async Task<PaymentDTO> PatchAsync(PaymentUpdateDTO dto) {
            this.Logger.LogDebug($"{nameof(PaymentUpdateService)} called for {dto.PaymentId}");

            return this.Mapper.Map<PaymentDTO>(
                await this.PaymentUpdateService.UpdateAsync(Mapper.Map<PaymentUpdateModel>(dto)));
        }

        [HttpDelete]
        [Route("{clientId}")]
        public async Task DeleteAsync(int clientId) {
            this.Logger.LogDebug($"{nameof(PaymentDeleteService)} called for {clientId}");
            await PaymentDeleteService.DeleteAsync(new PaymentIdentityModel(clientId));
        }
    }
}