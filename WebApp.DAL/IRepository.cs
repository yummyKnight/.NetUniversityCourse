using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Entities;
using WebApp.Domain.Contracts;
using WebApp.Domain.Models;

namespace WebApp.DAL {
    public interface IRepository<TDomainClass, TIdentityModel, TUpdateModel>
        where TDomainClass : class
        where TIdentityModel : class
        where TUpdateModel : class {
        Task<IEnumerable<TDomainClass>> GetByAsync(); // получение всех объектов
        Task<TDomainClass> GetByAsync(TIdentityModel model); // получение одного объекта по id
        Task<TDomainClass> CreateAsync(TUpdateModel model); // создание объекта
        Task<TDomainClass> UpdateAsync(TUpdateModel model); // обновление объекта
        Task DeleteAsync(TIdentityModel model); // удаление объекта по id
    }

    public interface IClientRepository : IRepository<Domain.Client, IClientContainer, ClientUpdateModel> {
    }
}