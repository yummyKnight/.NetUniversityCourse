﻿using WebApp.Domain.Base;
using WebApp.Domain.Contracts;

namespace WebApp.Domain.Models {
    public class ClientUpdateModel : BaseClient, IClientContainer {
        public int? ClientId { get; set; }
    }
}