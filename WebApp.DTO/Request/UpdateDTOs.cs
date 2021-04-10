using System.ComponentModel.DataAnnotations;

namespace WebApp.DTO.Request {
    public class ClientUpdateDTO : ClientCreateDTO {
        [Required(ErrorMessage = "ClientId is required")]
        public int ClientId { get; set; }
    }
}