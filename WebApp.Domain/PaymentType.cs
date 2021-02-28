namespace WebApp.Domain {
    public class PaymentType {
        public PaymentType(uint id) {
            Id = id;
        }

        public uint Id { get; }
        public string Type { get; set; }
    }
}