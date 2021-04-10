using System.ComponentModel.DataAnnotations;
using WebApp.Domain.Base;

namespace WebApp.DTO.Request {
    public class ClientCreateDTO : BaseClient {
        [Required(ErrorMessage = "Full name is required")]
        public new string FullName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public new string Address { get; set; }

        public new uint OrdersNum { get; set; }
    }
}