using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Domain;
using WebApp.Domain.Contracts;

namespace WebApp.BLL.Contracts {
    public interface IClientGetService : IGetService<IClientContainer, Client>{
    }
    
    
    
}