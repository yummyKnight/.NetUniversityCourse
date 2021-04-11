using System;
using System.Threading.Tasks;
using WebApp.BLL.Contracts;
using WebApp.Domain;
using WebApp.Domain.Contracts;
using WebApp.Domain.Models;
using EntityPayment = WebApp.DAL.Entities.Payment;
using DomainPayment = WebApp.Domain.Payment;
using IPaymentRep =
    WebApp.DAL.IRepository<WebApp.Domain.Payment, WebApp.Domain.Contracts.IPaymentContainer,
        WebApp.Domain.Models.PaymentUpdateModel>;

namespace WebApp.BLL.Implementations {
    public class
        PaymentGetService : GenericGetService<IPaymentRep, PaymentUpdateModel, DomainPayment, IPaymentContainer> {
        public override async Task ValidateAsync(IPaymentContainer model) {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var booking = await GetAsync(model);
            if (model.PaymentId.HasValue && booking == null)
            {
                throw new InvalidOperationException($"Payment not found by id {model.PaymentId}");
            }
        }

        public PaymentGetService(IPaymentRep repository) : base(repository) {
        }
    }

    public class PaymentUpdateService : IUpdateService<PaymentUpdateModel, IPaymentContainer, DomainPayment> {
        private IPaymentRep _repository;
        private IGetService<IClientContainer, Client> client_service;
        private IGetService<IBookingContainer, Booking> booking_service;
        private IGetService<IPaymentContainer, DomainPayment> payment_service;

        public PaymentUpdateService(IPaymentRep repository, IGetService<IClientContainer, Client> clientService,
            IGetService<IBookingContainer, Booking> bookingService,
            IGetService<IPaymentContainer, Payment> paymentService) {
            _repository = repository;
            client_service = clientService;
            booking_service = bookingService;
            payment_service = paymentService;
        }

        public async Task<DomainPayment> UpdateAsync(PaymentUpdateModel model) {
            await booking_service.ValidateAsync(model);
            await client_service.ValidateAsync(model);
            await payment_service.ValidateAsync(model);
            return await _repository.UpdateAsync(model);
        }
    }

    public class PaymentCreateService : ICreateService<PaymentUpdateModel, IPaymentContainer, DomainPayment> {
        private IPaymentRep _repository;
        private IGetService<IClientContainer, Client> client_service;
        private IGetService<IBookingContainer, Booking> booking_service;

        public PaymentCreateService(IPaymentRep repository, IGetService<IClientContainer, Client> clientService,
            IGetService<IBookingContainer, Booking> bookingService) {
            _repository = repository;
            client_service = clientService;
            booking_service = bookingService;
        }

        public async Task<DomainPayment> CreateAsync(PaymentUpdateModel model) {
            await client_service.ValidateAsync(model);
            await booking_service.ValidateAsync(model);
            return await _repository.CreateAsync(model);
        }
    }

    public class PaymentDeleteService : IDeleteService<IPaymentContainer> {
        private IPaymentRep _repository;
        private IGetService<IPaymentContainer, DomainPayment> payment_service;

        public PaymentDeleteService(IPaymentRep repository, IGetService<IPaymentContainer, Payment> paymentService) {
            _repository = repository;
            payment_service = paymentService;
        }

        public async Task DeleteAsync(IPaymentContainer model) {
            await payment_service.ValidateAsync(model);
            await _repository.DeleteAsync(model);
        }
    }
}