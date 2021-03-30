namespace WebApp.Domain.Contracts {
    public interface IBookingContainer {
        int? BookingId { get; }
    }

    public interface IClientContainer {
        int? ClientId { get; }
    }

    public interface IPaymentContainer {
        int? PaymentId { get; }
    }

    public interface IPaymentTypeContainer {
        int? PaymentTypeId { get; }
    }

    public interface IRoomContainer {
        int? RoomId { get; }
    }

    public interface IRoomTypeContainer {
        int? RoomTypeId { get; }
    }
}